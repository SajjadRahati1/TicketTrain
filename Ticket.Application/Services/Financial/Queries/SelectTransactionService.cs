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
using Ticket.Common;

namespace Ticket.Application.Services.Financial.Queries
{
    public interface ISelectTransactionService : IPublicService<RequestSelectTransactionDto, List<ResultSelectTransactionDto>>
    {

    }
    public class SelectTransactionService : ISelectTransactionService
    {
        private readonly IDbContext _context;

        public SelectTransactionService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<ResultSelectTransactionDto>>> Execute(RequestSelectTransactionDto request)
        {
            try
            {
                var fromDate = request.FromDate.ToMiladi();
                var toDate = request.ToDate.ToMiladi();
                request.SearchText =string.IsNullOrWhiteSpace(request.SearchText)?null:request.SearchText;
                var res = await
                    _context
                    .Transactions
                    .Include(t => t.Wallet)
                    .ThenInclude(t => t.User)
                    .Include(t=>t.RefrenceType)
                    .Where(t=>
                        (request.Id!= null || request.Id == t.Id) &&
                        (request.UserId!= null || request.UserId == t.Wallet.UserId) &&
                        (request.ReferenceType!= null || (int)request.ReferenceType == t.RefrenceTypeID) &&
                        (fromDate!= null || fromDate<= t.PaidDate) &&
                        (toDate!= null || toDate>= t.PaidDate) &&
                        (request.FromPrice!= null || request.FromPrice<= t.Amount) &&
                        (request.ToPrice!= null || request.ToPrice>= t.Amount) &&
                        (
                            request.SearchText!= null || 
                            t.Title.Contains(request.SearchText) ||
                            t.Description.Contains(request.SearchText) ||
                            t.TrackingCodeBank.Contains(request.SearchText) ||
                            t.Amount.ToString().Contains(request.SearchText)
                         )
                    )
                    .ToPaged(request.Page,request.PageSize,out int count)
                    .Select(t=>new ResultSelectTransactionDto()
                    {
                        Amount = t.Amount,
                        Id = t.Id,
                        IsFinished =t.IsFinished,
                        IsPaid = t.IsPaid,
                        PaidDate = t.PaidDate,
                        ReferenceType =t.RefrenceType.Title,
                        Title = t.Title,
                        UserId = t.Wallet.User.Id,
                        UserName = t.Wallet.User.UserName??""
                    })
                    .ToListAsync();
                if (res == null)
                    return new ResultDto<List<ResultSelectTransactionDto>>()
                    {
                        IsSuccess = true,
                        Data = new List<ResultSelectTransactionDto>(),
                        Message = "تراکنشی یافت نشد",
                        MessageType = MessageType.Info
                    };

               
                return new ResultDto<List<ResultSelectTransactionDto>>()
                {
                    IsSuccess = true,
                    Data = res,
                    Message = "OK",
                    MessageType = MessageType.Success
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<List<ResultSelectTransactionDto>>()
                {
                    IsSuccess = false,
                    Message = "تراکنش یافت نشد",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestSelectTransactionDto
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public ReferenceType? ReferenceType { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public string SearchText { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    public class ResultSelectTransactionDto
    {
        public long? Id { get; set; }
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
        /// تاریخ پرداخت
        /// </summary>
        public DateTime? PaidDate { get; set; }
    
        public string? Title { get; set; }
        

   
        /// <summary>
        ///نوع را مشخص میکند برای مثال 
        ///پرداخت برای بلیط هواپیما است
        ///پس باید در رفرنس آیدی، آیدی بلیط های دریافتی باشد
        /// </summary>
        public string ReferenceType { get; set; }

        public long UserId { get; set; }
        public string UserName { get; set; }
        
    }
}
