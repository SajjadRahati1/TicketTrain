using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Common.Dto;

namespace Ticket.Infrastructure.Sms
{
    public class KavenegarSms : ISmsPanel
    {
        private string Sender;
        private string Key;
        private readonly IConfiguration _confiquration;

        public KavenegarSms(IConfiguration configuration)
        {
            _confiquration = configuration.GetSection("SmsPanel:Kavenegar");
           
        }

      
        public ResultDto SendToOnePerson(SendSmsRequest request)
        {
            Sender = _confiquration["sender"]?.ToString()??"";
            Key = _confiquration["key"]?.ToString()??"";
            var api = new Kavenegar.KavenegarApi(Key);
            var res =api.Send(Sender, request.PhoneNumber, request.Text);
            if (res == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "خطایی در ارسال پیام رخ داده است",
                    MessageType = MessageType.Error
                };
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "پیامک با موفقیت ارسال شد",
                MessageType = MessageType.Success
            };
        }
    }
    public class SendSmsRequest
    {
        public string PhoneNumber { get; set; }
        public string Text { get; set; }
    }
}
