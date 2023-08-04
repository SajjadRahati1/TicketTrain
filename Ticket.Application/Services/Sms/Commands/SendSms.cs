using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Services;
using Ticket.Application.Services.Email.Commands;
using Ticket.Common.Dto;

namespace Ticket.Application.Services.Sms.Commands
{
    public interface ISendSms : IPublicService<RequestSendSmsDto, ResultSendSmsDto>
    {

    }
    public class SendSms : ISendSms
    {
        public async Task<ResultDto<ResultSendSmsDto>> Execute(RequestSendSmsDto request)
        {
            //var client = new WebClient();
            //string url = $"http://panel.kavenegar.com/v1/apikey/verify/lookup.json?receptor={PhoneNumber}&token={Code}&template=VerifyBugetoAccount";
            //var content= client.DownloadString(url);
            return new ResultDto<ResultSendSmsDto>()
            {
                IsSuccess = true,
                Message="فرض کنید پیام با موفقیت ارسال شد »:کد ارسالی"+request.Code
            };
        }

    }
    public class RequestSendSmsDto
    {
        public string PhoneNumber { get; set;}
        public string Code { get; set;}
    }
    public class ResultSendSmsDto
    {
    }
}
