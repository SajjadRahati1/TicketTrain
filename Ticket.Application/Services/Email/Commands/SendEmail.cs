using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Financial;
using Ticket.Domain.Entities.Users;

namespace Ticket.Application.Services.Email.Commands
{
    public interface ISendEmailService : IPublicService<RequestSendEmailDto>
    {

    }

    public class SendEmailService : ISendEmailService
    {
        public SendEmailService()
        {
           
        }
        public async Task<ResultDto> Execute(RequestSendEmailDto request)
        {
            try
            {
                //SmtpClient client = new SmtpClient();
                //client.Port = 587;
                //client.Host = "smtp.gmail.com";
                //client.EnableSsl = true;
                //client.Timeout = 1000000;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                ////در خط بعدی ایمیل  خود و پسورد ایمیل خود  را جایگزین کنید
                //client.Credentials = new NetworkCredential("sajadrahaty2@gmail.com", "AIzaSyBLe3sFlShxf-CPE9cn29E7qWSycVOO1j0");
                //MailMessage message = new MailMessage("sajadrahaty2@gmail.com", request.EmailAddress, request.Header, request.Text);
                //message.IsBodyHtml = true;
                //message.BodyEncoding = UTF8Encoding.UTF8;
                //message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                //client.Send(message);
                //return new ResultDto{
                //    IsSuccess = true,
                //    Message = message.Subject,
                //    MessageType = MessageType.Success
                //};
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "فرض کنید ایمیل با موفقیت ارسال شد »:متن ایمیل\n" + request.Text,
                    MessageType = MessageType.Success
                };
               

            }
            catch (Exception e)
            {
                //ثبت در لاگ ها
                string errorMessages = e.Message;
                return new ResultDto()
                {
                    
                    IsSuccess = false,
                    Message = "ثبت پیام انجام نشد !"
                };
            }
        }

       
    }
    public class RequestSendEmailDto
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Header { get; set; }
        public string Text { get; set; }
       

    }


    //public class ResultSendEmailDto
    //{
       
    //}


    
}
