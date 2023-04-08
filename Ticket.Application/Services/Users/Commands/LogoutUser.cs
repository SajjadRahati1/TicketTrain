using Microsoft.AspNetCore.Identity;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Commands
{
    public interface ILogoutUserService : IPublicService
    {

    }
    public class LogoutUser : ILogoutUserService
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutUser(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<ResultDto> Execute()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return new ResultDto { IsSuccess = true };
            }
            catch (Exception e)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "مشکلی در خروج از اکانت به وجود آمده"
                };
                //create log

            }
           
        }
    }
}
