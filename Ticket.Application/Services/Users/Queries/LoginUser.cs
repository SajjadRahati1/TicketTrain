using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Queries
{
    public interface ILoginUserService : IPublicService<RequestLoginUserDto, ResultLoginUserDto>
    {

    }
    public class LoginUser : ILoginUserService
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginUser(UserManager<User> userManager, SignInManager<User> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ResultDto<ResultLoginUserDto>> Execute(RequestLoginUserDto request)
        {

            await _signInManager.SignOutAsync();
            User? user;
            if (request.IsEmailAddress)
            {
                user = await _userManager.FindByEmailAsync(request.Username);
            }
            else
            {
                user = await _userManager.FindByNameAsync(request.Username);

            }
            if (user == null)
            {
                var str = request.IsEmailAddress ? "ایمیل" : "نام کاربری";
                return new ResultDto<ResultLoginUserDto>
                {
                    IsSuccess = false,
                    Message = $"کاربری با این {str} یافت نشد"
                };
            }
            var result = await _signInManager
                .PasswordSignInAsync(user,
                request.Password,
                request.IsPersistent,//مرا به خاطر بسپار
                true //فعال باشد که اگر چند بار رمز اشتباه زد قفل شود برای چند دقیقه مشخص طبق تنظیمات اعمال شده
                );

            if (result.Succeeded)
            {
                return new ResultDto<ResultLoginUserDto>()
                {
                    IsSuccess = true,
                    Data = new ResultLoginUserDto()
                    {
                        UserId = user.Id,
                        RedirectAddress = request.ReturnUrl,
                        IsRedirectAction = false
                    },
                    Message = $"{user.UserName} عزیز خوش آمدید"
                };
            }
            if (result.RequiresTwoFactor)
            {
                return new ResultDto<ResultLoginUserDto>()
                {
                    IsSuccess = true,
                    Data = new ResultLoginUserDto()
                    {
                        UserId = user.Id,
                        RedirectAddress = "TwoFactorLogin",
                        IsRedirectAction = true,
                        RedirectValues = new
                        {
                            request.Username,
                            request.IsPersistent
                        }
                    },
                    Message = $"{user.UserName} عزیز خوش آمدید، تایید دو مرحله ای"
                };
            }
            if (result.IsLockedOut) //کاربر تعداد دفعات رمز اشتباهش زیاد بوده و قفل شده
            {
                return new ResultDto<ResultLoginUserDto>
                {

                    IsSuccess = false,
                    Message = $"تعداد دفعات ارسال رمز عبور اشتباه شما بیش از حد مجاز شده است لطفا " +
                    $"{user.LockoutEnd.Value.Minute} " +
                    $"دقیقه دیگر تلاش کنید"
                };

            }
            return new ResultDto<ResultLoginUserDto>()
            {
                IsSuccess = false,
                Message = "لاگین شما با موفقیت نبود",
                MessageType = MessageType.Warning
            };
        }
    }

    public class RequestLoginUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// لاگین با ایمیل
        /// </summary>
        public bool IsEmailAddress { get; set; } = false;

        /// <summary>
        /// مرا به خاطر بسپار
        /// </summary>
        [Display(Name = "مرا به خاطر داشته باش")]
        public bool IsPersistent { get; set; } = false;

        public string ReturnUrl { get; set; }
    }

    public class ResultLoginUserDto
    {
        public long UserId { get; set; }
        public string RedirectAddress { get; set; }
        public bool IsRedirectAction { get; set; }
        public object RedirectValues { get; set; }
    }
    
    

}
