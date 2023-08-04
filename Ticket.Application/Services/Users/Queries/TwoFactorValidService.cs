using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Application.Services.Email.Commands;
using Ticket.Application.Services.Sms.Commands;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Users.Queries
{
    public interface ITwoFactorValidService : IPublicService<RequestTwoFactorValidDto, ResultTwoFactorValidDto>
    {

    }
    public class TwoFactorValidService : ITwoFactorValidService
    {
        private readonly IDbContext _context;
        private readonly UserManager<User> _userManager;

        public TwoFactorValidService(IDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResultDto<ResultTwoFactorValidDto>> Execute(RequestTwoFactorValidDto request)
        {
            try
            {
                var user = _userManager.FindByNameAsync(request.UserName).Result;
                if (user == null)
                {
                    return new ResultDto<ResultTwoFactorValidDto>()
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد",
                        MessageType = MessageType.BadRequest
                    };
                }

                var providers = _userManager.GetValidTwoFactorProvidersAsync(user).Result;

                ResultTwoFactorValidDto model = new ResultTwoFactorValidDto();
                ResultDto sendVal = new ResultDto();
                if (providers.Contains("Phone"))
                {
                    string smsCode = _userManager.GenerateTwoFactorTokenAsync(user, "Phone").Result;

                    SendSms smsService = new SendSms();
                    sendVal = await smsService.Execute(new RequestSendSmsDto()
                    {
                        PhoneNumber = user.PhoneNumber,
                        Code = smsCode
                    });
                    model.Provider = "Phone";
                    model.IsPersistent = request.IsPersistent;

                }
                else if (providers.Contains("Email"))
                {
                    string emailCode = _userManager.GenerateTwoFactorTokenAsync(user, "Email").Result;
                    SendEmailService emailService = new SendEmailService();
                    sendVal = await emailService.Execute(new RequestSendEmailDto
                    {
                        EmailAddress = user.Email,
                        Text = $"کد لاگین دو مرحله ای شما :{emailCode}",
                        Header = "لاگین دو مرحله ای"
                    });

                    model.Provider = "Email";
                    model.IsPersistent = request.IsPersistent;
                }
                return new ResultDto<ResultTwoFactorValidDto>()
                {
                    Data = model,
                    IsSuccess = sendVal.IsSuccess,
                    Message = sendVal.Message,
                    MessageType = sendVal?.MessageType ?? MessageType.Success
                };

            }
            catch (Exception e)
            {
                //ثبت در لاگ ها
                string errorMessages = e.Message;
                return new ResultDto<ResultTwoFactorValidDto>()
                {

                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }
    public class RequestTwoFactorValidDto
    {
        [Required]
        public string UserName { get; set; }
        public bool IsPersistent { get; set; }
    }
    public class ResultTwoFactorValidDto
    {
        public string Code { get; set; }
        public bool IsPersistent { get; set; }
        public string Provider { get; set; }
    }
   
}
