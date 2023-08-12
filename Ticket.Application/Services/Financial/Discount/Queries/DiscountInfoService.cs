using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Financial.Discount;
using Ticket.Domain.Entities.Refrences;

namespace Ticket.Application.Services.Financial.Discount.Queries
{
    public interface IDiscountInfoService : IPublicService<RequestDiscountInfoServiceDto, ResultDiscountInfoServiceDto>
    {

    }
    public class DiscountInfoService : IDiscountInfoService
    {
        private readonly IDbContext _context;

        public DiscountInfoService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultDiscountInfoServiceDto>> Execute(RequestDiscountInfoServiceDto request)
        {
            try
            {
                var res = await
                    _context
                    .Discounts
                    .FirstOrDefaultAsync(d =>
                        (request.DiscountId == null || request.DiscountId == d.Id) &&
                        (request.DiscountCode == null || request.DiscountCode == d.DiscountCode)

                    //(request.ReferenceType==null || request.DiscountCode == d.DiscountCode)&&
                    );
                if (res == null)
                    return new ResultDto<ResultDiscountInfoServiceDto>()
                    {
                        IsSuccess = false,
                        Message = "تخفیف مورد نظر یافت نشد",
                        MessageType = MessageType.Error
                    };
                var now = DateTime.Now;
                ResultDto resultDto = new ResultDto() { IsSuccess = true, };
                if (request.ForUse)
                {

                    if (res.StartDate != null && res.StartDate >= now)
                        resultDto = new ResultDto() { IsSuccess = false, Message = "تخفیف مورد نظر در دسترس نیست" };
                    if (res.EndDate != null && res.EndDate <= now)
                        resultDto = new ResultDto() { IsSuccess = false, Message = "تخفیف مورد نظر در دسترس نیست" };
                }
                var countUsed = await _context.UsedDiscounts.CountAsync(d => d.DiscountId == res.Id);
                if (request.ForUse)
                {
                    if (res.MaxUse - countUsed <= 0)
                        resultDto = new ResultDto() { IsSuccess = false, Message = "ظرفیت استفاده از این تخفیف اتمام شده است" };
                    if (request.UserId != null)
                    {
                        bool thisUserUsedThisDiscount = await _context.UsedDiscounts.AnyAsync(d => d.DiscountId == res.Id && d.UserId == request.UserId);
                        if (thisUserUsedThisDiscount)
                            resultDto = new ResultDto() { IsSuccess = false, Message = "شما قبلا از این تخفیف یک بار استفاده کرده اید" };
                        if (request.IsDoubleDiscount == true && res.IsDoubleDiscount == true)
                            resultDto = new ResultDto() { IsSuccess = false, Message = "از این تخفیف نمیتوان به عنوان تخفیف چندگانه استفاده کرد" };
                    }

                    if (!resultDto.IsSuccess)
                        return new ResultDto<ResultDiscountInfoServiceDto>()
                        {
                            IsSuccess = false,
                            Message = resultDto.Message,
                            MessageType = MessageType.Error
                        };
                }

                var result = new ResultDiscountInfoServiceDto()
                {
                    CountUse = countUsed,
                    Id = res.Id,
                    DiscountCode = res.DiscountCode,
                    EndDate = res.EndDate,
                    Important = res.Important,
                    IsDoubleDiscount = res.IsDoubleDiscount,
                    IsPercent = res.IsPrecent,
                    MaxDiscount = res.MaxDiscount,
                    MaxUse = res.MaxUse,
                    Name = res.Name,
                    ReferenceId = res.RefrenceId,
                    ReferenceTypeID = res.RefrenceTypeID,
                    StartDate = res.StartDate,
                    Value = res.Value,
                };

                return new ResultDto<ResultDiscountInfoServiceDto>()
                {
                    IsSuccess = true,
                    Data = result,
                    Message = "با موفقیت دریافت شد",
                    MessageType = MessageType.Success
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<ResultDiscountInfoServiceDto>()
                {
                    IsSuccess = false,
                    Message = "خطای ناشناخته در دریافت اطلاعات",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestDiscountInfoServiceDto
    {
        public string? DiscountCode { get; set; }
        public long? DiscountId { get; set; }
        /// <summary>
        /// برای اینکه اگر شخص یک بار از یه تخفیف استفاده کرد دیگه نتونه از همون تخفیف استفاده کنه
        /// </summary>
        public long? UserId { get; set; }
        /// <summary>
        /// زمانی که کاربر کد رو وارد میکنه برای استفاده از این تخفیف
        /// </summary>
        public bool ForUse { get; set; }
        /// <summary>
        /// اگر کاربر میخواهد به عنوان تخفیف دومش یا بیشتر این تخفیف رو استفاده کنه
        /// </summary>
        public bool? IsDoubleDiscount { get; set; }
        //public int? ReferenceType { get; set; }
        //public long? ReferenceId { get; set; }

    }
    public class ResultDiscountInfoServiceDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// تخفیف به صورت درصدی باشد
        /// </summary>
        public bool IsPercent { get; set; }

        /// <summary>
        /// مقداری که باید تخفیف داده شود به صورت درصد و یا به همان مبلغ تعیین شده
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// ماکسیمم تعداد استفاده
        /// </summary>
        public int? MaxUse { get; set; }

        /// <summary>
        /// اگر به صورت درصدی بود حداکثر مبلغ تخفیف چقدر باشد
        /// </summary>
        public decimal? MaxDiscount { get; set; }

        /// <summary>
        /// تاریخ شروع به استفاده
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان استفاده
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// در چه زمینه ای هست این تخفیف
        /// (اختیاری)
        /// </summary>
        public int? ReferenceTypeID { get; set; }
        /// <summary>
        /// برای یک سفر-پرواز-یا .. خاص است
        /// </summary>
        public long? ReferenceId { get; set; }

        /// <summary>
        /// کد تخفیف
        /// در صورت وجود داشتن کد تخفیف باید به صورت منحصر به فرد باشد
        /// </summary>
        public string? DiscountCode { get; set; }

        /// <summary>
        /// هرچقدر اهمیت بیشتر باشد این تخفیف در اولویت بیشتری قرار گرفته خواهد شد
        /// برای مثال زمانی که چند تخفیف را کاربر استفاده میکند با کمک این مقدار مشخص میشود کدام یکی باید ابتدا اعمال شود
        /// </summary>
        public int Important { get; set; }

        /// <summary>
        /// در تخفیف های چند تایی بشود اعمال کرد
        /// اگر این گزینه فعال نباشد و این تخفیف روی بلیطی باشد دیگر نمیتوان که تخفیف دیگری را روی خرید اعمال کرد
        /// نکته : این گزینه زمانی کارا است که به صورت کد تخفیف نباشد و به صورت خودکار روی بلیط اعمال شده باشد
        /// </summary>
        public bool IsDoubleDiscount { get; set; } = true;

        /// <summary>
        /// استفاده شده این تخفیف
        /// </summary>
        public int CountUse { get; set; }
    }

}
