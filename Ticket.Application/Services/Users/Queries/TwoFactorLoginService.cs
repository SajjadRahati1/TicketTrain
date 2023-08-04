using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Queries
{
    public interface ITwoFactorLoginService : IPublicService<RequestTwoFactorLoginDto, ResultTwoFactorLoginDto>
    {

    }
    public class TwoFactorLoginService : ITwoFactorLoginService
    {
        private readonly IDbContext _context;
        private readonly SignInManager<User> _signInManager;

        public TwoFactorLoginService(IDbContext context, SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<ResultDto<ResultTwoFactorLoginDto>> Execute(RequestTwoFactorLoginDto request)
        {
            try
            {
                var user = _signInManager.GetTwoFactorAuthenticationUserAsync().Result;
                if (user == null)
                {
                    return new ResultDto<ResultTwoFactorLoginDto>()
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد",
                        MessageType = MessageType.BadRequest
                    };
                }

                var result = _signInManager.TwoFactorSignInAsync(request.Provider, request.Code, request.IsPersistent, false).Result;

                if (result.Succeeded)
                {
                    return new ResultDto<ResultTwoFactorLoginDto>()
                    {
                        Data = new ResultTwoFactorLoginDto()
                        {
                            RedirectToAction = "Index"
                        },
                        IsSuccess = true,
                        Message = "لاگین با موفقیت انجام شد",
                        MessageType = MessageType.Success
                    };
                }
                else if (result.IsLockedOut)
                {
                    return new ResultDto<ResultTwoFactorLoginDto>()
                    {
                        IsSuccess = false,
                        Message = "حساب کاربری شما قغل شده است",
                        MessageType = MessageType.Warning
                    };
                }
                return new ResultDto<ResultTwoFactorLoginDto>()
                {
                    IsSuccess = false,
                    Message = "کد وارد شده صحیح نیست ",
                    MessageType = MessageType.Error
                };

            }
            catch (Exception e)
            {
                //ثبت در لاگ ها
                string errorMessages = e.Message;
                return new ResultDto<ResultTwoFactorLoginDto>()
                {

                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }
    public class RequestTwoFactorLoginDto
    {
        [Required]
        public string Code { get; set; }
        public bool IsPersistent { get; set; }
        public string Provider { get; set; }
    }
    public class ResultTwoFactorLoginDto
    {
        public string RedirectToAction { get; set; }
    }
}
