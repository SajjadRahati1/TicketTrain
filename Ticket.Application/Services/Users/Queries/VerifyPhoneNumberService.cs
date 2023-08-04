using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Queries
{
    public interface IVerifyPhoneNumberService : IPublicService<RequestVerifyPhoneNumberServiceDto>
    {

    }
 
    public class VerifyPhoneNumberService : IVerifyPhoneNumberService
    {
        public UserManager<User> _userManager { get; }

        public VerifyPhoneNumberService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ResultDto> Execute(RequestVerifyPhoneNumberServiceDto request)
        {
            try
            {
                var user = _userManager.FindByNameAsync(request.UserIdentityName).Result;
                bool resultVerify = await _userManager
                    .VerifyChangePhoneNumberTokenAsync(user, request.Code, request.PhoneNumber);
                if (resultVerify == false)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = $"کد وارد شده برای شماره {request.PhoneNumber} اشتباه اشت",
                        MessageType = MessageType.Warning
                    };
                   
                }
                else
                {
                    user.PhoneNumberConfirmed = true;
                    var resultUpdate = _userManager.UpdateAsync(user).Result;
                }
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = ""
                };
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
    public class RequestVerifyPhoneNumberServiceDto
    {
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string Code { get; set; }

        public string UserIdentityName { get; set; }
    }
}
