using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;

namespace Ticket.Application.Services.References.DomesticFlight.Queries
{
    public interface ISelectFilterDFService : IPublicService<RequestSelectFilterDF, List<ResultSelectFilterDF>>
    {

    }
    public class SelectFilterDFService : ISelectFilterDFService
    {
        private readonly IDbContext _context;

        public SelectFilterDFService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<ResultSelectFilterDF>>> Execute(RequestSelectFilterDF request)
        {
            try
            {
                DateTime fromDate = request?.FromDate?.ToMiladi() ?? DateTime.MinValue;
               // DateTime toDate = request?.ToDate?.ToMiladi() ?? DateTime.MinValue;
                var hasFromDate = fromDate != DateTime.MinValue;
                var res = await
                    _context
                    .DomesticFlights
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.AirLine)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.AirPlane)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.DestinationTerminal)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.OriginTerminal)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.Tags)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.Class)
                    .ThenInclude(c => c.ClassType)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.Pricing)
                    .Where(df =>
                        df.IsRemoved == false &&
                        df.Reservations.Count() < df.Flight.MaxNumberPassenger &&
                        df.Flight.OriginTerminal.CityId == request.FromCityId &&
                        df.Flight.DestinationTerminal.CityId == request.ToCityId &&
                        (!hasFromDate || df.Flight.StartMoving.Date == fromDate.Date) //&&
                        //(request.FromTime <= df.Flight.StartMoving.Date.Hour)
                    )
                    .Select(df => new ResultSelectFilterDF()
                    {
                        FlightId = df.FlightId,
                        DomesticFlightId = df.Id,
                        FlightNumber = df.Flight.FlightNumber,
                        AirLineId = df.Flight.AirLineId,
                        AirlineCode = df.Flight.AirLine.Code,
                        AirlineLogo = df.Flight.AirLine.LogoUrl,
                        AirlineName = df.Flight.AirLine.Name,
                        EndMovingDateTime = df.Flight.EndMoving,
                        StartMovingDateTime = df.Flight.StartMoving,
                        Class = df.Flight.Class.Name,
                        ClassTypeID = df.Flight.Class.ClassTypeId,
                        ClassTypeName = df.Flight.Class.ClassType.Name,
                        Description = df.Flight.Description ?? "",
                        Destination = df.Flight.DestinationTerminalId,
                        DestinationName = df.Flight.DestinationTerminal.Name +
                                (df.Flight.DestinationTerminal.Name != df.Flight.DestinationTerminal.City.Name ?
                                " " + df.Flight.DestinationTerminal.City.Name :
                                ""
                                ),

                        OriginId = df.Flight.OriginTerminalId,
                        OriginName = df.Flight.OriginTerminal.Name +
                                (df.Flight.OriginTerminal.Name != df.Flight.OriginTerminal.City.Name ?
                                " " + df.Flight.OriginTerminal.City.Name :
                                ""
                                ),
                        IsCharter = df.Flight.IsCharter,
                        MaxAllowdBaggage = df.Flight.AllowableAmountLoad /*- _context.TicketDomesticFlights*/,
                        PriceAdult = df.Flight.Pricing.AdultPrice,
                        PriceTeenage = df.Flight.Pricing.TeenagePrice,
                        PriceChild = df.Flight.Pricing.ChildPrice,
                        Seat = df.Flight.MaxNumberPassenger,
                        Stars = df.Flight.AirPlane.Rank
                    }).ToListAsync();
                for (int i = 0; i < res.Count; i++)
                {
                    var f = res[i];
                    //محاسبه جای خالی مانده
                    try
                    {
                        f.Seat -= await _context
                               .TicketDomesticFlights
                               .Include(tf => tf.Reservation)
                               .CountAsync(tf =>
                                   !tf.IsRemoved &&
                                   tf.ReturnedId == null &&
                                   tf.Reservation.FlightId == f.DomesticFlightId &&
                                   tf.Reservation.TransactionId != null //حتما اون هایی که پرداخت داشتن
                               );
                    }
                    catch (Exception ex)
                    {

                    }

                    //دریافت قوانین استرداد
                    f.ResultTicketRefundRules = await _context
                               .FlightTicketRefundRules
                               .Include(r => r.GroupRules)
                               .ThenInclude(r => r.Flights.Where(fl => fl.Id == f.FlightId))
                               .Where(r =>
                                   !r.IsRemoved &&
                                   !r.GroupRules.IsRemoved
                               )
                               .Select(r => new ResultTicketRefundRulesDto()
                               {
                                   DeductibleAmount = r.DeductibleAmount,
                                   Description = r.Description,
                                   EndHour = r.EndHour,
                                   End_AfterIssuanceTicket = r.End_AfterIssuanceTicket,
                                   End_BeforeFlight = r.End_BeforeFlight,
                                   IsPercent = r.IsPercent,
                                   StartHour = r.StartHour,
                                   Start_AfterIssuanceTicket = r.Start_AfterIssuanceTicket,
                                   Start_BeforeFlight = r.Start_BeforeFlight,
                                   Title = r.Title
                               }).ToListAsync();
                }
                //res.ForEach(async f =>
                //{
                   

                //});

                return new ResultDto<List<ResultSelectFilterDF>>()
                {
                    IsSuccess = true,
                    Data = res,
                    Message = "دریافت لیست با موفقیت انجام شد"
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<List<ResultSelectFilterDF>>()
                {
                    IsSuccess = false,
                    Message = "خطا در دریافت اطلاعات",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestSelectFilterDF
    {
        public long FromCityId { get; set; }
        public long ToCityId { get; set; }
        public string FromDate { get; set; }
        //public string ToDate { get; set; }
        public int CountPassenger { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
       // public int TicketType { get; set; }

        ///// <summary>
        ///// تعداد مسافران بزرگسال
        ///// </summary>
        //public int CountAdultPassenger { get; set; }
        ///// <summary>
        ///// تعداد مسافران نوجوان
        ///// </summary>
        //public int CountTeenagePassenger { get; set; }
        ///// <summary>
        ///// تعداد مسافران کودک
        ///// </summary>
        //public int CountChildPassenger { get; set; }
    }
    public class ResultSelectFilterDF
    {
        public long DomesticFlightId { get; set; }
        public long FlightId { get; set; }
        /// <summary>
        /// شماره پرواز
        /// </summary>
        public string FlightNumber { get; set; }
        /// <summary>
        /// هواپیمای هوایی
        /// جزو سه badge بالا
        /// </summary>
        public string AirCraft { get; set; }
        /// <summary>
        /// شماره ترمینال
        /// مثال : ترمینال : شماره 2
        /// </summary>
        public int TerminalNumber { get; set; }
        public string AirlineCode { get; set; }
        public long AirLineId { get; set; }
        public string AirlineLogo { get; set; }
        public string AirlineName { get; set; }
        //public List<string> AppliedRules { get; set; }
        public DateTime EndMovingDateTime { get; set; }
        public long DiscountId { get; set; }
        public string DiscountText { get; set; }
        public string Class { get; set; }
        public long ClassTypeID { get; set; }
        /// <summary>
        /// پرواز : اکونومی
        /// </summary>
        public string ClassTypeName { get; set; }
        public int Commission { get; set; }
        public string GroupRefundRulesTitle { get; set; }
        public List<ResultTicketRefundRulesDto> ResultTicketRefundRules { get; set; }
        public string Description { get; set; }
        public long Destination { get; set; }
        public string DestinationName { get; set; }
        
        public bool IsCharter { get; set; }
        public bool IsRefundable { get; set; }
        public bool IsSelectableInRoundtrip { get; set; }
        public DateTime StartMovingDateTime { get; set; }
        public int MaxAllowdBaggage { get; set; }
        public long OriginId { get; set; }
        public string OriginName { get; set; }
        public decimal PriceAdult { get; set; }
        public decimal PriceChild { get; set; }
        public decimal PriceTeenage { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int Seat { get; set; }
        public short Stars { get; set; }
    }
    public class ResultTicketRefundRulesDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        /// <summary>
        /// مبلغ قابل کسر
        /// </summary>
        public decimal DeductibleAmount { get; set; }

        /// <summary>
        /// مبلغ به صورت درصدی در نظر گرفته شود
        /// </summary>
        public bool IsPercent { get; set; }

        /// <summary>
        /// شروع از چه مدت پس از صدور بلیط
        /// </summary>
        public TimeSpan? Start_AfterIssuanceTicket { get; set; }
        /// <summary>
        /// پایان از چه مدت پس از صدور بلیط
        /// </summary>
        public TimeSpan? End_AfterIssuanceTicket { get; set; }
        //مثال : از زمان صدور بلیط تا 4 روز پس از آن مهلت انقضا به این قانون استرداد وجود دارد

        /// <summary>
        /// شروع از چه مدت قبل از پرواز
        /// </summary>
        public TimeSpan? Start_BeforeFlight { get; set; }
        /// <summary>
        /// پایان از چه مدت قبل از پرواز
        /// </summary>
        public TimeSpan? End_BeforeFlight { get; set; }
        //مثال : از 2 روز قبل از پرواز تا 1 روز قبل از پرواز مهلت انقضا به این قانون استرداد وجود دارد

        /// <summary>
        /// در روز استرداد بلیط شروع از چه ساعتی باشد
        /// </summary>
        public short? StartHour { get; set; }
        /// <summary>
        /// در روز استرداد بلیط شروع از چه ساعتی باشد
        /// </summary>
        public short? EndHour { get; set; }
    }
}
