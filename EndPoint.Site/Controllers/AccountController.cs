using EndPoint.Site.Models.Dto.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using NuGet.Packaging.Signing;
using System.Net.Mail;
using Ticket.Application.Services.Email.Commands;
using Ticket.Application.Services.Users.Commands;
using Ticket.Application.Services.Users.FacadPattern;
using Ticket.Application.Services.Users.Queries;
using Ticket.Common;
using Ticket.Common.Interfaces.FacadPatterns;
using Ticket.Domain.Entities.Users;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserFacad _userFacad;
        private readonly IFinancialFacad _financialFacad;
        private readonly IDomesticFlightFacad _domesticFlightFacad;
        private readonly ISendEmailService _sendEmail;
        private readonly UserManager<User> _userManager;
        public AccountController(IUserFacad userFacad, ISendEmailService sendEmail, UserManager<User> userManager, IFinancialFacad financialFacad, IDomesticFlightFacad domesticFlightFacad)
        {
            _userFacad = userFacad;
            _sendEmail = sendEmail;
            _userManager = userManager;
            _financialFacad = financialFacad;
            _domesticFlightFacad = domesticFlightFacad;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var res = await _userFacad.UserInfoService.Execute(User.Identity.Name);
            return View(new AccountIndexDto()
            {
                BrithDate = res.Data.BrithDate,
                EmailAddress = res.Data.EmailAddress,
                EmailVerified = res.Data.EmailVerified,
                Money = res.Data.Money,
                Name = res.Data.Name,
                NationalCode = res.Data.NationalCode,
                PhoneNumber = res.Data.PhoneNumber,
                PhoneNumberVerified = res.Data.PhoneNumberVerified,
                Username = res.Data.Username,
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
        public async Task<IActionResult> Orders(OrdersDto req)
        {
            var user = await _userManager.GetUserAsync(User);
            var res = await _domesticFlightFacad.SelectTicketReservationDFService.Execute(new Ticket.Application.Services.References.DomesticFlight.Queries.RequestSelectTicketReservationDFDto()
            {
                IsRemoved = req.IsRemoved,
                IsReturned = req.IsReturned,
                Page = req.Page,
                PageSize = req.PageSize,
                UserId = user.Id,
                DomesticFlightId= req.DomesticFlightId,
                TicketReservationId= req.TicketReservationId,
                SearchText = req.SearchText,
                PassengerId = req.PassengerId
            });
            req.IsSuccess = res.IsSuccess;
            req.Message = res.Message;
            req.TypeMessage = res.MessageType.ToString();
            if(!res.IsSuccess)
            {
                return View(req);
            }
            req.Orders = res.Data.Select(o => new OrderDto()
            {
                FlightNumber = o.Flight.FlightNumber,
                FromCity = o.Flight.FromCity,
                Id = o.Id,
                IsRemoved = o.IsRemoved,
                MovingDate = o.Flight.MovingDate.ToShamsi(),
                OrderNumber = o.OrderNumber,
                PhoneNumber = o.User.PhoneNumber,
                RemoveDateTime = o.RemoveDateTime.ToShamsi(),
                TicketNumber = o.TicketNumber,
                TicketsCount = o.TicketsCount,
                ToCity = o.Flight.ToCity,
                UserName = o.User.UserName
            }).ToList();
            return View(req);
        }
        [Authorize]
        public async Task<IActionResult> Passengers(PassengersDto request)
        {
            var user = await _userManager.GetUserAsync(User);
            var passengers = await _userFacad.PassengersListService.Execute(new Ticket.Application.Services.Passengers.Queries.RequestPassnegerListDto()
            {
                Page = request.Page,
                PageSize = request.PageSize,
                SearchText = "",
                UserId = user.Id
            });
            if (passengers == null || !passengers.IsSuccess)
            {
                return View(request);
            }
            request.Passengers = passengers.Data.Select(p => new PassengerDto()
            {
                FullName_En = p.FullName_En,
                FullName_Fa = p.FullName_Fa,
                Gender = p.Gender ? "مرد" : "زن",
                NationalCode = p.NationalCode,
                PassportNumber = p.PassportNumber,
                Id = p.Id
            }).ToList();
            request.OutCount = (int)passengers.OutCount;
            return View(request);
        }
        [Authorize]
        public async Task<IActionResult> Transactions(TransactionsDto request)
        {
            var user = await _userManager.GetUserAsync(User);
            var tr = await _financialFacad.SelectTransactionService.Execute(new Ticket.Application.Services.Financial.Queries.RequestSelectTransactionDto()
            {
                FromDate = request.FromDate,
                FromPrice = request.FromPrice,
                //Id = request.FromPrice,
                Page = request.Page,
                PageSize = request.PageSize,
                //ReferenceType = request.ReferenceType.
                SearchText = request.SearchText,
                ToDate = request.ToDate,
                ToPrice = request.ToPrice,
                UserId = user.Id
            });
            if (tr == null || !tr.IsSuccess)
            {
                request.Message = tr?.Message ?? "خطا در دریافت اطلاعات";
                request.TypeMessage = tr?.MessageType.ToString()??"Error";
                request.IsSuccess = false;
                return View(request);
            }
            request.IsSuccess = true;
            request.Message = tr.Message;
            request.TypeMessage = tr.MessageType.ToString();

            request.Transactions = tr.Data.Select(t=>new TransactionDto()
            {
                Amount = t.Amount,
                Id = t.Id,
                IsFinished = t.IsFinished,
                IsPaid = t.IsPaid,
                PaidDate = t.PaidDate.ToShamsi(),
                ReferenceType = t.ReferenceType,
                Title = t.Title,
                UserId = t.UserId,
                UserName = t.UserName
            }).ToList();
            return View(request);
        }

        [Authorize]
        public async Task<IActionResult> AddPassenger(AddPassengerDto req)
        {
            var user = await _userManager.GetUserAsync(User);
            var res = await _userFacad.AddPassengerService.Execute(new RequestAddPassengerDto()
            {
                BirthDte = req.BirthDte,
                CountryBirthId = req.CountryBirthId,
                EmailAddress = req.EmailAddress,
                En_FirstName = req.En_FirstName,
                En_LastName = req.En_LastName,
                ExpireDatePassport = req.ExpireDatePassport,
                FirstName = req.FirstName,
                Gender = req.Gender,
                LastName = req.LastName,
                NationalCode = req.NationalCode,
                PhoneNumber = req.PhoneNumber,
                UserId = user.Id
            });
            req.IsSuccess = res.IsSuccess;
            req.Message = res.Message;
            req.TypeMessage = res.MessageType.ToString();
            
            return View(req);
        }
        [Authorize]
        public async Task<IActionResult> EditPassenger(EditPassenger req)
        {
            var user = await _userManager.GetUserAsync(User);
            var res = await _userFacad.EditPassengerService.Execute(new RequestEditPassengerDto()
            {
                BirthDte = req.BirthDte,
                CountryBirthId = req.CountryBirthId,
                EmailAddress = req.EmailAddress,
                En_FirstName = req.En_FirstName,
                En_LastName = req.En_LastName,
                ExpireDatePassport = req.ExpireDatePassport,
                FirstName = req.FirstName,
                Gender = req.Gender,
                LastName = req.LastName,
                NationalCode = req.NationalCode,
                PhoneNumber = req.PhoneNumber,
                PassengerId = req.Id
            });
            req.IsSuccess = res.IsSuccess;
            req.Message = res.Message;
            req.TypeMessage = res.MessageType.ToString();
            
            return View(req);
        }
        
    }
}
