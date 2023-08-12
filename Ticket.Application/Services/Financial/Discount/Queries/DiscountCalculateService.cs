using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;

namespace Ticket.Application.Services.Financial.Discount.Queries
{
    public interface IDiscountCalculateService : IPublicService<RequestDiscountCalculateServiceDto, ResultDiscountCalculateServiceDto>
    {

    }
    public class DiscountCalculateService : IDiscountCalculateService
    {
        private readonly IDbContext _context;

        public DiscountCalculateService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultDiscountCalculateServiceDto>> Execute(RequestDiscountCalculateServiceDto request)
        {
            try
            {

                var discount = await new DiscountInfoService(_context).Execute(new RequestDiscountInfoServiceDto()
                {
                    DiscountCode = request.DiscountCode,
                    DiscountId = request.DiscountId,
                    ForUse = true,
                    IsDoubleDiscount = request.IsDoubleDiscount,
                    UserId = request.UserId
                });

                if (!discount.IsSuccess)
                    return new ResultDto<ResultDiscountCalculateServiceDto>()
                    {
                        IsSuccess = false,
                        Message = discount.Message,
                        MessageType = discount.MessageType
                    };
                var data = discount.Data;
                decimal newCost = request.CurrentCost;
                decimal discountVal = 0;
                if (data.IsPercent)
                    discountVal = data.Value / 100 * newCost;
                else
                    discountVal = data.Value;

                if (discountVal > (data.MaxDiscount ?? 0))
                    discountVal = data.MaxDiscount ?? 0;

                //از ایمپورتنت استفاده نشده
                newCost -= discountVal;
                if (newCost < 0)
                    newCost = 0;
                return new ResultDto<ResultDiscountCalculateServiceDto>()
                {
                    IsSuccess = true,
                    Data = new ResultDiscountCalculateServiceDto()
                    {
                        CostWithDiscount = newCost,
                        Id = data.Id,
                        NameDiscount = data.Name
                    },
                    Message = "تخفیف اعمال شد",
                    MessageType = MessageType.Success

                };
            }
            catch (Exception ex)
            {
                return new ResultDto<ResultDiscountCalculateServiceDto>()
                {
                    IsSuccess = false,
                    Message = "خطای ناشناخته در دریافت اطلاعات",
                    MessageType = MessageType.Error
                };
            }
        }
    }


    public class RequestDiscountCalculateServiceDto
    {
        public string? DiscountCode { get; set; }
        public long? DiscountId { get; set; }
        /// <summary>
        /// برای اینکه اگر شخص یک بار از یه تخفیف استفاده کرد دیگه نتونه از همون تخفیف استفاده کنه
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// اگر کاربر میخواهد به عنوان تخفیف دومش یا بیشتر این تخفیف رو استفاده کنه
        /// </summary>
        public bool? IsDoubleDiscount { get; set; }
        public decimal CurrentCost { get; set; }

    }
    public class ResultDiscountCalculateServiceDto
    {
        public long? Id { get; set; }
        public string NameDiscount { get; set; }
        public decimal CostWithDiscount { get; set; }
    }
}
