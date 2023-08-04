using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Financial;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Queries
{

    public interface IConfirmEmailService : IPublicService<RequestConfirmEmailDto, ResultConfirmEmailDto>
    {

    }

    public class ConfirmEmailService : IConfirmEmailService
    {
        private readonly IDbContext _context;
        private readonly UserManager<User> _userManager;

        public ConfirmEmailService(IDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResultDto<ResultConfirmEmailDto>> Execute(RequestConfirmEmailDto request)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                    return new ResultDto<ResultConfirmEmailDto>()
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد",
                        MessageType = MessageType.Error,
                        Data = new ResultConfirmEmailDto() { RedirectAction = "Error" }
                    };
                var result = await _userManager.ConfirmEmailAsync(user, request.Token);
                if (result.Succeeded)
                {

                    return new ResultDto<ResultConfirmEmailDto>()
                    {
                        Data = new ResultConfirmEmailDto()
                        {
                            RedirectAction = "Login"
                        },
                        IsSuccess = true,
                        Message = "ثبت نام کاربر انجام شد",
                    };
                }
                else if (result.Errors.Any())
                {
                    string errorMessages = "";
                    foreach (var error in result.Errors)
                    {
                        errorMessages += error.Description + Environment.NewLine;
                        //ثبت در لاگ ها
                    }
                    return new ResultDto<ResultConfirmEmailDto>()
                    {
                        Data = new ResultConfirmEmailDto { RedirectAction = "Error" },
                        IsSuccess = true,
                        Message = errorMessages,
                    };
                }

                return new ResultDto<ResultConfirmEmailDto>()
                {
                    Data = new ResultConfirmEmailDto { RedirectAction = "Error" },
                    IsSuccess = true,
                    Message = "خطای ناشناخته",
                };

            }
            catch (Exception e)
            {
                //ثبت در لاگ ها
                string errorMessages = e.Message;
                return new ResultDto<ResultConfirmEmailDto>()
                {
                    Data = new ResultConfirmEmailDto()
                    {
                        RedirectAction = "Error"
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }

    public class RequestConfirmEmailDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }


    }
    public class ResultConfirmEmailDto
    {
        public string RedirectAction { get; set; }
    }
}
