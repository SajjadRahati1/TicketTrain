using Microsoft.AspNetCore.Hosting;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Services.Financial.Command;
using Ticket.Application.Services.Financial.Discount.Commands;
using Ticket.Application.Services.Financial.Discount.Queries;
using Ticket.Application.Services.Financial.Queries;
using Ticket.Common.Interfaces.FacadPatterns;

public class FinancialFacad : IFinancialFacad
{
    private readonly IDbContext _context;
    private readonly IHostingEnvironment _environment;

    public FinancialFacad(IDbContext context, IHostingEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    #region IAddEditTransactionService
    private IAddEditTransactionService _addEditTransaction;
    public IAddEditTransactionService AddEditTransactionService
    {
        get
        {
            return _addEditTransaction = _addEditTransaction ?? new AddEditTransactionService(_context);
        }
    }
    #endregion

    #region ISelectTransactionService
    private ISelectTransactionService _selectTransactionService;
    public ISelectTransactionService SelectTransactionService
    {
        get
        {
            return _selectTransactionService = _selectTransactionService ?? new SelectTransactionService(_context);
        }
    }
    #endregion

    #region ITransactionInfoService
    private ITransactionInfoService _transactionInfoService;
    public ITransactionInfoService TransactionInfoService
    {
        get
        {
            return _transactionInfoService = _transactionInfoService ?? new TransactionInfoService(_context);
        }
    }
    #endregion

    #region Discounts

    #region IAddEditDiscountService
    private IAddEditDiscountService _addEditDiscountService;
    public IAddEditDiscountService AddEditDiscountService
    {
        get
        {
            return _addEditDiscountService = _addEditDiscountService ?? new AddEditDiscountService(_context);
        }
    }
    #endregion

    #region IDiscountCalculateService
    private IDiscountCalculateService _discountCalculateService;
    public IDiscountCalculateService DiscountCalculateService
    {
        get
        {
            return _discountCalculateService = _discountCalculateService ?? new DiscountCalculateService(_context);
        }
    }
    #endregion

    #region IDiscountInfoService
    private IDiscountInfoService _discountInfoService;
    public IDiscountInfoService DiscountInfoService
    {
        get
        {
            return _discountInfoService = _discountInfoService ?? new DiscountInfoService(_context);
        }
    }
    #endregion
    
    #region IAddEditDiscountService
    private ISelectDiscountService _selectUsedDiscountService;
    public ISelectDiscountService SelectDiscountService
    {
        get
        {
            return _selectUsedDiscountService = _selectUsedDiscountService ?? new SelectDiscountService(_context);
        }
    }
    #endregion
    
    #region IAddEditDiscountService
    private ISelectUsedDiscountService _selectDiscountService;
    public ISelectUsedDiscountService SelectUsedDiscountService
    {
        get
        {
            return _selectDiscountService = _selectDiscountService ?? new SelectUsedDiscountService(_context);
        }
    }
    #endregion

    #endregion
}