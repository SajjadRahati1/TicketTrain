using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Financial.Discount;
using Ticket.Domain.Entities.Refrences;
using Ticket.Domain.Entities.Refrences.Bus;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
using Ticket.Domain.Entities.Refrences.Flight.InternationalFlight;
using Ticket.Domain.Entities.Refrences.Train;
using Ticket.Domain.Enums;

namespace Ticket.Application.Services.Financial.Discount.Queries
{
    public interface ISelectDiscountService : IPublicService<RequestSelectDiscountServiceDto, List<ResultSelectDiscountServiceDto>>
    {

    }
    public class SelectDiscountService : ISelectDiscountService
    {
        private readonly IDbContext _context;

        public SelectDiscountService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<ResultSelectDiscountServiceDto>>> Execute(RequestSelectDiscountServiceDto request)
        {

            try
            {
                var fromDate = request.FromDate.ToMiladi();
                var toDate = request.ToDate.ToMiladi();


                var res = await
                            _context
                            .Discounts
                            .Include(d => d.RefrenceType)
                            .Where(d =>
                                (fromDate == null || fromDate <= d.StartDate) &&
                                (toDate == null || toDate >= d.EndDate) &&
                                (request.ReferenceType == null || request.ReferenceType == d.RefrenceTypeID) &&
                                (request.ReferenceId == null || request.ReferenceId == d.RefrenceId) &&
                                (request.IsDoubleDiscount == null || request.IsDoubleDiscount == d.IsDoubleDiscount) &&
                                (request.IsPercent == null || request.IsPercent == d.IsPrecent) &&
                                (
                                    request.SearchText == null ||
                                    d.Name.Contains(request.SearchText)
                                )

                            //(request.ReferenceType==null || request.DiscountCode == d.DiscountCode)&&
                            )
                            .ToPaged(request.Page, request.PageSize, out int count)
                            .Select(d => new
                            {
                                DiscountCode = d.DiscountCode,
                                EndDate = d.EndDate,
                                Id = d.Id,
                                Important = d.Important,
                                IsDoubleDiscount = d.IsDoubleDiscount,
                                IsPercent = d.IsPrecent,
                                MaxDiscount = d.MaxDiscount,
                                MaxUse = d.MaxUse,
                                Name = d.Name,
                                ReferenceTypeID = d.RefrenceTypeID,
                                ReferenceTypeTitle = d.RefrenceType != null ? d.RefrenceType.Title : null,
                                ReferenceId = d.RefrenceId,
                                StartDate = d.StartDate,
                                Value = d.Value,
                                ReferenceTypeEnum = d.RefrenceType.EntityName,
                               
                            })
                            .ToListAsync();
                List<ResultSelectDiscountServiceDto> result = new List<ResultSelectDiscountServiceDto>();
                if (res == null)
                    return new ResultDto<List<ResultSelectDiscountServiceDto>>()
                    {
                        IsSuccess = true,
                        Message = "هیچ تخفیفی یافت نشد",
                        MessageType = MessageType.Info
                    };
                res.ForEach(async r =>
                {
                    var add = new ResultSelectDiscountServiceDto
                    {
                        DiscountCode = r.DiscountCode,
                        EndDate = r.EndDate,
                        Id = r.Id,
                        Important = r.Important,
                        IsDoubleDiscount = r.IsDoubleDiscount,
                        IsPercent = r.IsPercent,
                        MaxDiscount = r.MaxDiscount,
                        MaxUse = r.MaxUse,
                        Name = r.Name,
                        ReferenceTypeID = r.ReferenceTypeID,
                        ReferenceTypeTitle = r.ReferenceTypeTitle,
                        ReferenceId = r.ReferenceId,
                        StartDate = r.StartDate,
                        Value = r.Value
                    };
                    add.CountUse = await _context.UsedDiscounts.CountAsync(d => d.DiscountId == r.Id);
                    switch (r.ReferenceTypeEnum)
                    {
                        case ReferenceType.DomesticFlight:
                            DomesticFlight dFlight = await _context.DomesticFlights.Include(d => d.Flight).FirstOrDefaultAsync(d => d.Id == r.ReferenceId);
                            add.ReferenceTitle = dFlight.Flight.SmallTitle ?? "پرواز داخلی شماره " + dFlight.Flight.FlightNumber;
                            break;
                        case ReferenceType.InternationalFlights:
                            InternationalFlight iFlight = await _context.InternationalFlights.Include(d => d.Flight).FirstOrDefaultAsync(d => d.Id == r.ReferenceId);
                            add.ReferenceTitle = iFlight.Flight.SmallTitle ?? "پرواز خارجی شماره " + iFlight.Flight.FlightNumber;
                            break;
                        case ReferenceType.TravelBus:
                            BusTravel tBus = await _context.BusTravels.FirstOrDefaultAsync(d => d.Id == r.ReferenceId);
                            add.ReferenceTitle = tBus.SmallTitle;
                            break;
                        case ReferenceType.TravelTrain:
                            TrainTravel tTrain = await _context.TrainTravels.FirstOrDefaultAsync(d => d.Id == r.ReferenceId);
                            add.ReferenceTitle = tTrain.SmallTitle;
                            break;
                        default:
                            break;
                    }

                    result.Add(add);
                });


                return new ResultDto<List<ResultSelectDiscountServiceDto>>()
                {
                    IsSuccess = true,
                    Data = result,
                    Message = "با موفقیت دریافت شد",
                    MessageType = MessageType.Success,
                    OutCount = count
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<List<ResultSelectDiscountServiceDto>>()
                {
                    IsSuccess = false,
                    Message = "خطای ناشناخته در دریافت اطلاعات",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestSelectDiscountServiceDto
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? SearchText { get; set; }

        public bool? IsDoubleDiscount { get; set; }
        public bool? IsPercent { get; set; }
        public int? ReferenceType { get; set; }
        public long? ReferenceId { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; }
    }
    public class ResultSelectDiscountServiceDto
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

        public string? ReferenceTypeTitle { get; set; }
        /// <summary>
        /// برای یک سفر-پرواز-یا .. خاص است
        /// </summary>
        public long? ReferenceId { get; set; }
        public string? ReferenceTitle { get; set; }

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
