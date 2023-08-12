using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Financial.Discount;
using Ticket.Domain.Entities.Financial;
using Ticket.Domain.Entities.Refrences;
using Ticket.Domain.Enums;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ticket.Application.Services.Financial.Queries
{
    public interface ITransactionInfoService : IPublicService<RequestTransactionInfoDto, ResultTransactionInfoDto>
    {

    }
    public class TransactionInfoService : ITransactionInfoService
    {
        private readonly IDbContext _context;

        public TransactionInfoService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultTransactionInfoDto>> Execute(RequestTransactionInfoDto request)
        {
            try
            {
                var res = await
                    _context
                    .Transactions
                    .Include(t => t.Wallet)
                    .ThenInclude(t => t.User)
                    .FirstOrDefaultAsync(t=>t.Id==request.Id);
                if (res == null)
                    return new ResultDto<ResultTransactionInfoDto>()
                    {
                        IsSuccess = false,
                        Message = "تراکنش یافت نشد",
                        MessageType = MessageType.Error
                    };

                var result = new ResultTransactionInfoDto()
                {
                    Amount = res.Amount,
                    CreationDate = res.CreationDate,
                    Description = res.Description,
                    IsFinished = res.IsFinished,
                    IsPaid = res.IsPaid,
                    PaidDate = res.PaidDate,
                    ReferenceID = res.RefrenceID,
                    ReferenceType = (ReferenceType)res.RefrenceTypeID,
                    Title = res.Title,
                    TrackingCodeBank = res.TrackingCodeBank,
                    UserId = res.Wallet.User.Id,
                    UserName = res.Wallet.User.UserName ?? "",
                };

                return new ResultDto<ResultTransactionInfoDto>()
                {
                    IsSuccess = true,
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<ResultTransactionInfoDto>()
                {
                    IsSuccess = false,
                    Message = "تراکنش یافت نشد",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestTransactionInfoDto
    {
        public long Id { get; set; }
    }
    public class ResultTransactionInfoDto
    {
        public decimal Amount { get; set; }
        /// <summary>
        /// آیا پرداختی است یا دریافتی
        /// </summary>
        public bool IsPaid { get; set; }
        /// <summary>
        /// عملیات به درستی به اتمام رسیده و پرداخت شده است
        /// </summary>
        public bool IsFinished { get; set; }
       
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime? PaidDate { get; set; }
    
        public string? Title { get; set; }
        public string? Description { get; set; }
        /// <summary>
        /// کد پیگیری بانکی
        /// </summary>
        public string? TrackingCodeBank { get; set; }

        /// <summary>
        /// مبلغ بابت چه چیزی پرداخت یا دریافت شده است
        /// </summary>
        public long ReferenceID { get; set; }
        /// <summary>
        ///نوع را مشخص میکند برای مثال 
        ///پرداخت برای بلیط هواپیما است
        ///پس باید در رفرنس آیدی، آیدی بلیط های دریافتی باشد
        /// </summary>
        public ReferenceType ReferenceType { get; set; }

        public long UserId { get; set; }
        public string UserName { get; set; }
        
    }
}
