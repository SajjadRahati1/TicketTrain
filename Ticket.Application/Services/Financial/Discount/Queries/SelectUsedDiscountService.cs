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
    public interface ISelectUsedDiscountService : IPublicService<RequestSelectUsedDiscountServiceDto, List<ResultSelectUsedDiscountServiceDto>>
    {

    }
    public class SelectUsedDiscountService : ISelectUsedDiscountService
    {
        private readonly IDbContext _context;

        public SelectUsedDiscountService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<ResultSelectUsedDiscountServiceDto>>> Execute(RequestSelectUsedDiscountServiceDto request)
        {

            try
            {
                var fromDate = request.FromDate.ToMiladi();
                var toDate = request.ToDate.ToMiladi();


                var res = await
                            _context
                            .UsedDiscounts
                            .Include(d => d.Transaction)
                            .Include(d => d.User)
                            .Include(d => d.Discount)
                            .Include(d => d.RefrenceType)
                            .Where(d =>
                                d.UserId== request.UserId &&
                                (fromDate == null || fromDate <= d.Transaction.PaidDate) &&
                                (toDate == null || toDate >= d.Transaction.PaidDate) &&
                                (request.ReferenceType == null || request.ReferenceType == d.RefrenceTypeID) &&
                                (request.ReferenceId == null || request.ReferenceId == d.RefrenceId) &&
                                (
                                    request.SearchText == null ||
                                    d.Discount.Name.Contains(request.SearchText) ||
                                    d.Transaction.Title.Contains(request.SearchText) ||
                                    d.RefrenceType.Title.Contains(request.SearchText)
                                )

                            //(request.ReferenceType==null || request.DiscountCode == d.DiscountCode)&&
                            )
                            .ToPaged(request.Page, request.PageSize, out int count)
                            .Select(d => new
                            {
                                TransactionTitle =d.Transaction.Title,
                                GetDiscountDateTime = d.Transaction.PaidDate.ToShamsi(),
                                GetDiscountCost = d.GetDiscountCost,
                                DiscountName = d.Discount.Name,
                                ReferenceTypeID = d.RefrenceTypeID,
                                ReferenceTypeTitle = d.RefrenceType != null ? d.RefrenceType.Title : null,
                                ReferenceId = d.RefrenceId,

                                ReferenceTypeEnum = d.RefrenceType.EntityName,

                            })
                            .ToListAsync();
                List<ResultSelectUsedDiscountServiceDto> result = new List<ResultSelectUsedDiscountServiceDto>();
                if (res == null)
                    return new ResultDto<List<ResultSelectUsedDiscountServiceDto>>()
                    {
                        IsSuccess = true,
                        Message = "هیچ تخفیفی یافت نشد",
                        MessageType = MessageType.Info
                    };
                res.ForEach(async r =>
                {
                    var add = new ResultSelectUsedDiscountServiceDto
                    {
                        TransactionTitle = r.TransactionTitle,
                        GetDiscountDateTime = r.GetDiscountDateTime,
                        GetDiscountCost = r.GetDiscountCost,
                        DiscountName = r.DiscountName,
                        ReferenceTypeID = r.ReferenceTypeID,
                        ReferenceTypeTitle = r.ReferenceTypeTitle,
                        ReferenceId = r.ReferenceId,
                    };
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


                return new ResultDto<List<ResultSelectUsedDiscountServiceDto>>()
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
                return new ResultDto<List<ResultSelectUsedDiscountServiceDto>>()
                {
                    IsSuccess = false,
                    Message = "خطای ناشناخته در دریافت اطلاعات",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestSelectUsedDiscountServiceDto
    {
        public long UserId { get; set; }
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
    public class ResultSelectUsedDiscountServiceDto
    {
        public string TransactionTitle { get; set; }
        public string GetDiscountDateTime { get; set; }
        public decimal GetDiscountCost { get; set; }
        public string DiscountName { get; set; }
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

     
    }

}
