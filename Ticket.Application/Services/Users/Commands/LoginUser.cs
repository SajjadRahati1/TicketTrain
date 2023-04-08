using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Commands
{
    public interface ILoginUserService : IPublicService<RequestLoginUserDto, long>
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

        public async Task<ResultDto<long>> Execute(RequestLoginUserDto request)
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
                return new ResultDto<long>
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
                return new ResultDto<long>()
                {
                    IsSuccess = true,
                    Data = user.Id,
                    Message = $"{user.UserName} عزیز خوش آمدید"
                };
            }
            if (result.IsLockedOut) //کاربر تعداد دفعات رمز اشتباهش زیاد بوده و قفل شده
            {
                return new ResultDto<long>
                {
                    Data = 0,
                    IsSuccess = false,
                    Message = $"تعداد دفعات ارسال رمز عبور اشتباه شما بیش از حد مجاز شده است لطفا " +
                    $"{user.LockoutEnd.Value.Minute} " +
                    $"دقیقه دیگر تلاش کنید"
                };
                
            }
            return new ResultDto<long>()
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

        public bool IsPersistent { get; set; } = false;

        public string ReturnUrl { get; set; }
    }


    
}
