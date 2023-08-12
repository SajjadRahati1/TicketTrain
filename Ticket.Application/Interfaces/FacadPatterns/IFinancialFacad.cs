using Ticket.Application.Services.Financial.Command;
using Ticket.Application.Services.Financial.Discount.Commands;
using Ticket.Application.Services.Financial.Discount.Queries;
using Ticket.Application.Services.Financial.Queries;

namespace Ticket.Common.Interfaces.FacadPatterns
{
    public interface IFinancialFacad
    {
        IAddEditTransactionService AddEditTransactionService { get; }
        ISelectTransactionService SelectTransactionService { get; }
        ITransactionInfoService TransactionInfoService { get; }
        IAddEditDiscountService AddEditDiscountService { get; }
        IDiscountCalculateService DiscountCalculateService { get; }
        IDiscountInfoService DiscountInfoService { get; }
        ISelectDiscountService SelectDiscountService { get; }
        ISelectUsedDiscountService SelectUsedDiscountService { get; }
      
      
    }
}
