using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Financial.Discount;
using Ticket.Domain.Entities.Financial;
using Ticket.Domain.Entities.Refrences;
using Ticket.Domain.Enums;
using Ticket.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Ticket.Application.Services.Financial.Discount.Queries;
using System.Reflection.Metadata.Ecma335;

namespace Ticket.Application.Services.Financial.Command
{
    public interface IAddEditTransactionService : IPublicService<RequestAddEditTransactionDto, ResultAddEditTransactionDto>
    {

    }
    public class AddEditTransactionService : IAddEditTransactionService
    {
        private readonly IDbContext _context;

        public AddEditTransactionService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultAddEditTransactionDto>> Execute(RequestAddEditTransactionDto request)
        {
            Transaction transaction;
            Wallet wallet;
            if (request.Id == null)
            {
                var res = await AddTransaction(request);
                if (!res.IsSuccess)
                    return new ResultDto<ResultAddEditTransactionDto>()
                    {
                        IsSuccess = false,
                        Message = res.Message,
                        MessageType = res.MessageType
                    };
                transaction = res.Data.Transaction;
                wallet = res.Data.Wallet;
            }
            else
            {
                var res = await EditTransaction(request);
                if (!res.IsSuccess)
                    return new ResultDto<ResultAddEditTransactionDto>()
                    {
                        IsSuccess = false,
                        Message = res.Message,
                        MessageType = res.MessageType
                    };
                transaction = res.Data.Transaction;
                wallet = res.Data.Wallet;
            }

            _context.Transactions.Add(transaction);
            _context.Wallets.Add(wallet);

            var count = await _context.SaveChangesAsync();
            if (count < 0)
                return new ResultDto<ResultAddEditTransactionDto>()
                {
                    IsSuccess = false,
                    Message = "در ثبت اطلاعات خطایی وجود دارد",
                    MessageType = MessageType.Error
                };
            return new ResultDto<ResultAddEditTransactionDto>()
            {
                IsSuccess = true,
                Data = new ResultAddEditTransactionDto()
                {
                    TransactionId = transaction.Id,
                    FinalPrice = transaction.Amount
                },
                OutCount = count
            };
        }
        public async Task<ResultDto<(Transaction Transaction, Wallet Wallet)>> AddTransaction(RequestAddEditTransactionDto req)
        {
            var (finalCost,usedDiscounts) = await SubmitDiscount(req);


            Transaction transaction = new Transaction()
            {
                Amount = finalCost,
                CreationDate = DateTime.Now,
                Description = req.Description,
                IsFinished = req.IsFinished,
                IsPaid = req.IsPaid,
                PaidDate = req.IsFinished ? DateTime.Now : null,
                RefrenceID = req.ReferenceID,
                RefrenceTypeID = (int)req.ReferenceType,
                Title = req.Title,
                TrackingCodeBank = req.TrackingCodeBank,
                Discounts= usedDiscounts??new List<UsedDiscount>()
            };
            Wallet wallet;
            ResultDto<Wallet> resultWallet;
            if (req.IsFinished)
            {
                resultWallet = await EditUserWallet(req, finalCost);
                if (!resultWallet.IsSuccess)
                    return new ResultDto<(Transaction Transaction, Wallet Wallet)>()
                    {
                        IsSuccess = false,
                        Message = resultWallet.Message,
                        MessageType = resultWallet.MessageType
                    };
                wallet = resultWallet.Data;
                transaction.Wallet = wallet;
                transaction.WalletId = wallet.Id;
            }
            else
            {
                resultWallet = await GetWallet(req);
                if (!resultWallet.IsSuccess)
                    return new ResultDto<(Transaction Transaction, Wallet Wallet)>()
                    {
                        IsSuccess = false,
                        Message = resultWallet.Message,
                        MessageType = resultWallet.MessageType
                    };
                wallet = resultWallet.Data;
                transaction.Wallet = wallet;
                transaction.WalletId = wallet.Id;
            }

            return new ResultDto<(Transaction Transaction, Wallet Wallet)>()
            {
                IsSuccess = true,
                Data = (transaction, wallet)
            };
        }
        public async Task<ResultDto<(Transaction Transaction, Wallet Wallet)>> EditTransaction(RequestAddEditTransactionDto req)
        {

            var transaction = await _context.Transactions.Include(t => t.Discounts).FirstOrDefaultAsync(t => t.Id == req.Id);
            if (transaction == null)
                return new ResultDto<(Transaction Transaction, Wallet Wallet)>
                {
                    IsSuccess = false,
                    Message = "عملیات پرداخت یافت نشد",
                    MessageType = MessageType.BadRequest
                };
            decimal changedCost = 0;
            if (req.IsFinished &&  !transaction.IsFinished)
            {
                transaction.IsFinished = true;
                transaction.TrackingCodeBank = req.TrackingCodeBank;
                transaction.PaidDate = DateTime.Now;
            }
            if(!transaction.IsFinished)
            {
                transaction.Title = req.Title;
                transaction.Description = req.Description;
                if (req.Discounts != null)
                {
                    req.Discounts.AddRange(transaction.Discounts.Select(d => d.DiscountId).ToList());
                    //حذف موارد تکراری
                    req.Discounts = req.Discounts.Distinct().ToList();
                    var (finalCost, discs) = await SubmitDiscount(req);
                    changedCost = finalCost - transaction.Amount;
                    transaction.Amount = finalCost;
                    transaction.Discounts.AddRange(
                        discs
                        .Where(d => !transaction.Discounts.Any(td => td.DiscountId == d.DiscountId))
                        .ToList()
                        );
                }

            }
            
            Wallet wallet;
            ResultDto<Wallet> resultWallet;
            if (req.IsFinished && !transaction.IsFinished)
            {
                resultWallet = await EditUserWallet(req, changedCost);
                if (!resultWallet.IsSuccess)
                    return new ResultDto<(Transaction Transaction, Wallet Wallet)>()
                    {
                        IsSuccess = false,
                        Message = resultWallet.Message,
                        MessageType = resultWallet.MessageType
                    };
                wallet = resultWallet.Data;
                transaction.Wallet = wallet;
                transaction.WalletId = wallet.Id;
            }
            else
            {
                resultWallet = await GetWallet(req);
                if (!resultWallet.IsSuccess)
                    return new ResultDto<(Transaction Transaction, Wallet Wallet)>()
                    {
                        IsSuccess = false,
                        Message = resultWallet.Message,
                        MessageType = resultWallet.MessageType
                    };
                wallet = resultWallet.Data;
                transaction.Wallet = wallet;
                transaction.WalletId = wallet.Id;
            }

            return new ResultDto<(Transaction Transaction, Wallet Wallet)>()
            {
                IsSuccess = true,
                Data = (transaction, wallet)
            };
        }

        /// <summary>
        /// اعمال تخفیف ها
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<(decimal final, List<UsedDiscount> discounts)> SubmitDiscount(RequestAddEditTransactionDto req)
        {
            decimal finalCost = req.Amount;
            List<UsedDiscount> discounts = new List<UsedDiscount>();
            decimal prevCost = 0;
            if (req.Discounts != null)
            {
                bool isFirst = true;
                foreach (var disc in req.Discounts)
                {
                    //var discount = await new DiscountInfoService(_context).Execute(new RequestDiscountInfoServiceDto()
                    //{
                    //    DiscountId = disc,
                    //    ForUse = true,
                    //    UserId = req.UserId
                    //});
                    //if (!discount.IsSuccess)
                    //    continue;
                    prevCost = finalCost;
                    var calculateDisc = await new DiscountCalculateService(_context).Execute(new RequestDiscountCalculateServiceDto()
                    {
                        CurrentCost = finalCost,
                        DiscountId = disc,
                        UserId = req.UserId,
                        IsDoubleDiscount = !isFirst
                    });
                    if (!calculateDisc.IsSuccess)
                        continue;
                    finalCost = calculateDisc.Data.CostWithDiscount;
                    if (prevCost != finalCost)
                        discounts.Add(new UsedDiscount()
                        {
                            DiscountId = disc,
                            RefrenceId = req.ReferenceID,
                            RefrenceTypeID = (int)req.ReferenceType,
                            GetDiscountCost = prevCost - finalCost,
                            UserId = req.UserId
                        });
                    isFirst = false;
                }
            }
            return (finalCost, discounts);
        }

        public async Task<ResultDto<Wallet>> GetWallet(RequestAddEditTransactionDto req)
        {
            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == req.UserId);
            if (wallet == null)
                return new ResultDto<Wallet>()
                {
                    IsSuccess = false,
                    Message = "کیف پول یافت نشد",
                    MessageType = MessageType.Error
                };
            return new ResultDto<Wallet>()
            {
                IsSuccess = true,
                Data = wallet,
                MessageType = MessageType.Success
            };
        }
        public async Task<ResultDto<Wallet>> EditUserWallet(RequestAddEditTransactionDto req, decimal finalCost)
        {
            var wall = await GetWallet(req);
            Wallet wallet;
            if (!wall.IsSuccess)
                return wall;
            wallet = wall.Data;

            if (req.IsPaid)
                wallet.Balance -= finalCost;
            else wallet.Balance += finalCost;

            if (wallet.Balance < 0)
                return new ResultDto<Wallet>()
                {
                    IsSuccess = false,
                    Message = "مبلغ وارد شده کمتر از مبلغ قابل پرداخت است",
                    MessageType = MessageType.Error
                };

            return new ResultDto<Wallet>()
            {
                IsSuccess = true,
                Data = wallet,
                MessageType = MessageType.Success,
                Message = "ثبت مقدار در کیف پول با موفقیت انجام شد"
            };

        }
    }
    public class RequestAddEditTransactionDto
    {
        public long? Id { get; set; }
        public decimal Amount { get; set; }
        /// <summary>
        /// آیا پرداختی است یا دریافتی
        /// </summary>
        public bool IsPaid { get; set; }
        //public Wallet Wallet { get; set; }
        //public long WalletId { get; set; }
        public long UserId { get; set; }
        /// <summary>
        /// عملیات به درستی به اتمام رسیده و پرداخت شده است
        /// </summary>
        public bool IsFinished { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime? PaidDate { get; set; }
        /// <summary>
        /// عنوانی که باید بک اند پر کند
        /// </summary>
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

        /// <summary>
        /// اگر تخفیف دریافت کرده است در اینجا مشخص میشود
        /// </summary>
        public List<long>? Discounts { get; set; }
    }
    public class ResultAddEditTransactionDto
    {
        public long TransactionId { get; set; }
        public decimal FinalPrice { get; set; }
        
    }
}
