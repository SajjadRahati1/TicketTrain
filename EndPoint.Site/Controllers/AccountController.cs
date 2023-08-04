using EndPoint.Site.Models.Dto.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.Net.Mail;
using Ticket.Application.Services.Email.Commands;
using Ticket.Application.Services.Users.Commands;
using Ticket.Application.Services.Users.FacadPattern;
using Ticket.Application.Services.Users.Queries;
using Ticket.Common.Interfaces.FacadPatterns;
using Ticket.Domain.Entities.Users;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserFacad _userFacad;
        private readonly ISendEmailService _sendEmail;
        public AccountController(IUserFacad userFacad, ISendEmailService sendEmail)
        {
            _userFacad = userFacad;
            _sendEmail = sendEmail;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var res =await _userFacad.UserInfoService.Execute(User.Identity.Name);
            return View(new AccountIndexDto()
            {
                BrithDate = res.Data.BrithDate,
                EmailAddress = res.Data.EmailAddress,
                EmailVerified = res.Data.EmailVerified,
                Money = res.Data.Money,
                Name = res.Data.Name,
                NationalCode = res.Data.NationalCode,
                PhoneNumber = res.Data.PhoneNumber,
                PhoneNumberVerified= res.Data.PhoneNumberVerified,
                Username= res.Data.Username,
            });
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            if (ModelState.IsValid == false)
            {
                return View(register);
            }

            var result = await _userFacad.RegisterUserService.Execute(new RequestRegisterUserDto()
            {
                FirstName = register.FirstName,
                Username = register.Username,
                PhoneNumber = register.PhoneNumber,
                Password = register.Password,
                LastName = register.LastName,
                Email = register.Email,
                ConfirmPassword = register.ConfirmPassword,
            });
            if (result.IsSuccess)
            {


                string callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    UserId = result.Data.UserId,
                    token = result.Data.Token
                }, protocol: Request.Scheme);

                string body = $"لطفا برای فعال حساب کاربری بر روی لینک زیر کلیک کنید!  <br/> <a href={callbackUrl}> Link </a>";
                await _sendEmail.Execute(new RequestSendEmailDto()
                {
                    EmailAddress = register.Email,
                    Text = body,
                    Header = "فعال سازی حساب کاربری همسفر"
                });

                return RedirectToAction("DisplayEmail");
            }

            string message = result.Message;
            TempData["Message"] = message;
            TempData["MessageType"] = result.MessageType;
            return View(register);
        }


        public async Task<IActionResult> ConfirmEmail(string UserId, string Token)
        {
            if (UserId == null || Token == null)
            {
                return BadRequest();
            }
            var result = await _userFacad.ConfirmEmailService.Execute(new RequestConfirmEmailDto()
            {
                Token = Token,
                UserId = UserId
            });
            if (result.IsSuccess)
            {

                return RedirectToAction(result.Data.RedirectAction);
            }
            return RedirectToAction(result?.Data?.RedirectAction ?? "Error",
                new
                {
                    Message = result?.Message ?? ""
                    ,
                    Type = result?.MessageType
                });
        }
        public IActionResult DisplayEmail()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {

            return View(new LoginDto
            {
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            login.IsEmailAddress = IsValidEmail(login.Username);
            var result = await _userFacad.LoginUserService.Execute(new RequestLoginUserDto()
            {
                IsEmailAddress = login.IsEmailAddress,
                IsPersistent = login.IsPersistent,
                Password = login.Password,
                ReturnUrl = login.ReturnUrl,
                Username = login.Username,
            });
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message ?? "در ثبت اطلاعات مشکلی به وجود آمده");
                return View();
            }
            if (result.Data.IsRedirectAction)
            {
                return RedirectToAction(result.Data.RedirectAddress, result.Data.RedirectValues);
            }
            return Redirect(result.Data?.RedirectAddress ?? login.ReturnUrl);
        }
        private bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public async Task<IActionResult> TwoFactorLogin(string UserName, bool IsPersistent)
        {

            var result = await _userFacad.TwoFactorValidService.Execute(new RequestTwoFactorValidDto()
            {
                IsPersistent = IsPersistent,
                UserName = UserName
            });
            ViewData["Message"] = result.Message;
            ViewData["MessageType"] = result.MessageType;
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message ?? "در ثبت اطلاعات مشکلی به وجود آمده");
                return View();
            }
            var r = result.Data;
            return View(new TwoFactorLoginDto()
            {
                Code = r.Code,
                IsPersistent = r.IsPersistent,
                Provider = r.Provider,
            });

        }

        [HttpPost]
        public async Task<IActionResult> TwoFactorLogin(TwoFactorLoginDto twoFactor)
        {
            if (!ModelState.IsValid)
            {
                return View(twoFactor);
            }

            var result = await _userFacad.TwoFactorLoginService.Execute(new RequestTwoFactorLoginDto()
            {
                Code = twoFactor.Code,
                Provider = twoFactor.Provider,
                IsPersistent = twoFactor.IsPersistent
            });
            ViewData["Message"] = result.Message;
            ViewData["MessageType"] = result.MessageType;
            if (result.IsSuccess)
            {
                if (result.Data != null && !result.Data.RedirectToAction.IsNullOrEmpty())
                    return RedirectToAction(result.Data.RedirectToAction);

            }
            ModelState.AddModelError("", result.Message);
            return View();

        }
        public IActionResult LogOut()
        {
            var res = _userFacad.LogoutUserService.Execute();

            return RedirectToAction("Index", "home");
        }

        [Authorize]
        public IActionResult VerifyPhoneNumber()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> VerifyPhoneNumber(VerifyPhoneNumberDto verify)
        {
            var res = await _userFacad.VerifyPhoneNumberService.Execute(new RequestVerifyPhoneNumberServiceDto()
            {
                Code = verify.Code,
                PhoneNumber = verify.PhoneNumber,
                UserIdentityName = User.Identity.Name
            });
            if (res.IsSuccess)
            {
                ViewData["Message"] = res.Message;
                return View(verify);
            }

            return RedirectToAction("Index");

        }

        /// <summary>
        /// سفارشات
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Orders()
        {
            return View();
        }
        [Authorize]
        public IActionResult Passengers()
        {
            return View();
        }
        [Authorize]
        public IActionResult Transactions()
        {
            return View();
        }

    }
}
