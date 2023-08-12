using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Application.Services.Financial.Discount.Queries;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain;
using Ticket.Domain.Entities.Refrences;
using Ticket.Domain.Enums;

namespace Ticket.Application.Services.Financial.Discount.Commands
{
    public interface IAddEditDiscountService : IPublicService<RequestAddEditDiscountServiceDto>
    {

    }
    public class AddEditDiscountService : IAddEditDiscountService
    {
        private readonly IDbContext _context;

        public AddEditDiscountService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(RequestAddEditDiscountServiceDto request)
        {
            try
            {
                if (((request.MaxDiscount??0) < (request.Value??0)) && !(request.IsPercent??false))
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "مقدار ماکیزمم مبلغ نباید کمتر از مبلغ ورودی باشد",
                        MessageType = MessageType.Warning
                    };
                if ((request.IsPercent??false) && request.Value > 100)
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "مقدار ورودی بزرگتر از درصد است",
                        MessageType = MessageType.Warning
                    };
                Domain.Entities.Financial.Discount.Discount discount;
                if (request.Id != null)
                {
                    discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (discount == null)
                        return new ResultDto()
                        {
                            IsSuccess = false,
                            Message = "تخفیف مد نظر یافت نشد",
                            MessageType = MessageType.Warning
                        };
                    discount.DiscountCode = request.DiscountCode??request.DiscountCode;
                    discount.EndDate = request.EndDate.ToMiladi()?? discount.EndDate;
                    discount.Important = request.Important??0;
                    discount.IsDoubleDiscount = request.IsDoubleDiscount??discount.IsDoubleDiscount;
                    discount.IsPrecent = request.IsPercent?? discount.IsPrecent;
                    discount.MaxDiscount = request.MaxDiscount ?? discount.MaxDiscount;
                    discount.MaxUse = request.MaxUse ?? discount.MaxUse;
                    discount.Name = request.Name ?? discount.Name;
                    discount.RefrenceId = request.ReferenceId ?? discount.RefrenceId;
                    discount.RefrenceTypeID = (int?)request.ReferenceType ?? discount.RefrenceTypeID;
                    discount.StartDate = request.StartDate.ToMiladi() ?? discount.StartDate;
                    discount.Value = request.Value ?? discount.Value;

                    if (discount.MaxDiscount < discount.Value && !discount.IsPrecent)
                        return new ResultDto()
                        {
                            IsSuccess = false,
                            Message = "مقدار ماکیزمم مبلغ نباید کمتر از مبلغ ورودی باشد",
                            MessageType = MessageType.Warning
                        };
                    if (discount.IsPrecent && discount.Value > 100)
                        return new ResultDto()
                        {
                            IsSuccess = false,
                            Message = "مقدار ورودی بزرگتر از درصد است",
                            MessageType = MessageType.Warning
                        };
                }
                else
                    discount = new Domain.Entities.Financial.Discount.Discount()
                    {
                        DiscountCode = request.DiscountCode,
                        EndDate = request.EndDate.ToMiladi(),
                        Important = request.Important??0,
                        IsDoubleDiscount = request.IsDoubleDiscount??false,
                        IsPrecent = request.IsPercent??false,
                        MaxDiscount = request.MaxDiscount ?? request.Value??0,
                        MaxUse = request.MaxUse ?? 0,
                        Name = request.Name,
                        RefrenceId = request.ReferenceId,
                        RefrenceTypeID = (int?)request.ReferenceType,
                        StartDate = request.StartDate.ToMiladi(),
                        Value = request.Value ?? 0
                    };
                if(discount.Name.IsNullOrEmpty())
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "مقدار نام برای تخفیف الزامی است",
                        MessageType = MessageType.Warning
                    };
                if(request.Value<=0)
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "هیچ مقداری برای تخفیف مشخص نشده است",
                        MessageType = MessageType.Warning
                    };
                var count = await _context.SaveChangesAsync();
                if (count < 1)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "مشکلی در ثبت به وجود آمده",
                        MessageType = MessageType.Error
                    };
                }
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "ثبت با موفقیت انجام شد",
                    MessageType = MessageType.Success
                };
            }
            catch (Exception ex)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "مشکلی در ثبت به وجود آمده",

                    MessageType = MessageType.BadRequest
                };
            }
        }
    }
    public class RequestAddEditDiscountServiceDto
    {
        public long? Id { get; set; }
        /// <summary>
        /// تخفیف به صورت درصدی باشد
        /// </summary>
        public bool? IsPercent { get; set; }

        /// <summary>
        /// مقداری که باید تخفیف داده شود به صورت درصد و یا به همان مبلغ تعیین شده
        /// </summary>
        public decimal? Value { get; set; }

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
        public string? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان استفاده
        /// </summary>
        public string? EndDate { get; set; }

        /// <summary>
        /// در چه زمینه ای هست این تخفیف
        /// (اختیاری)
        /// </summary>

        public ReferenceType? ReferenceType { get; set; }
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
        public int? Important { get; set; }

        /// <summary>
        /// در تخفیف های چند تایی بشود اعمال کرد
        /// اگر این گزینه فعال نباشد و این تخفیف روی بلیطی باشد دیگر نمیتوان که تخفیف دیگری را روی خرید اعمال کرد
        /// نکته : این گزینه زمانی کارا است که به صورت کد تخفیف نباشد و به صورت خودکار روی بلیط اعمال شده باشد
        /// </summary>
        public bool? IsDoubleDiscount { get; set; } = true;
        public string? Name { get; set; }
    }

}
