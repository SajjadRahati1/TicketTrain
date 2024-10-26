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
    public interface IDomesticFlightInfoService : IPublicService<RequestDomesticFlightInfoService, ResultDomesticFlightInfoService>
    {

    }
    public class DomesticFlightInfoService : IDomesticFlightInfoService
    {
        private readonly IDbContext _context;

        public DomesticFlightInfoService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultDomesticFlightInfoService>> Execute(RequestDomesticFlightInfoService request)
        {
            try
            {

                var fligth = await
                    _context
                    .DomesticFlights
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.AirLine)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.AirPlane)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.DestinationTerminal)
                    .ThenInclude(f => f.City)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.OriginTerminal)
                    .ThenInclude(f => f.City)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.Tags)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.Class)
                    .ThenInclude(c => c.ClassType)
                    .Include(df => df.Flight)
                    .ThenInclude(f => f.Pricing)
                    .FirstOrDefaultAsync(df =>
                        df.IsRemoved == false &&
                        df.Id == request.FlightId
                    );
                if (fligth == null)
                    return new ResultDto<ResultDomesticFlightInfoService>()
                    {
                        IsSuccess = false,
                        Message = "پرواز درخواستی یافت نشد",
                        MessageType = MessageType.Error
                    };
                ResultDomesticFlightInfoService res = new ResultDomesticFlightInfoService()
                {
                    FlightId = fligth.FlightId,
                    DomesticFlightId = fligth.Id,
                    FlightNumber = fligth.Flight.FlightNumber,
                    AirLineId = fligth.Flight.AirLineId,
                    AirlineCode = fligth.Flight.AirLine.Code,
                    AirlineLogo = fligth.Flight.AirLine.LogoUrl,
                    AirlineName = fligth.Flight.AirLine.Name,
                    EndMovingDateTime = fligth.Flight.EndMoving,
                    StartMovingDateTime = fligth.Flight.StartMoving,
                    Class = fligth.Flight.Class.Name,
                    ClassTypeID = fligth.Flight.Class.ClassTypeId,
                    ClassTypeName = fligth.Flight.Class.ClassType.Name,
                    Description = fligth.Flight.Description ?? "",
                    Destination = fligth.Flight.DestinationTerminalId,
                    DestinationName = fligth.Flight.DestinationTerminal.Name +
                                (fligth.Flight.DestinationTerminal.Name != fligth.Flight.DestinationTerminal.City.Name ?
                                " " + fligth.Flight.DestinationTerminal.City.Name :
                                ""
                                ),

                    OriginId = fligth.Flight.OriginTerminalId,
                    OriginName = fligth.Flight.OriginTerminal.Name +
                                (fligth.Flight.OriginTerminal.Name != fligth.Flight.OriginTerminal.City.Name ?
                                " " + fligth.Flight.OriginTerminal.City.Name :
                                ""
                                ),
                    IsCharter = fligth.Flight.IsCharter,
                    MaxAllowdBaggage = fligth.Flight.AllowableAmountLoad /*- _context.TicketDomesticFlights*/,
                    PriceAdult = fligth.Flight.Pricing.AdultPrice,
                    PriceTeenage = fligth.Flight.Pricing.TeenagePrice,
                    PriceChild = fligth.Flight.Pricing.ChildPrice,
                    Seat = fligth.Flight.MaxNumberPassenger,
                    Stars = fligth.Flight.AirPlane.Rank
                };


                //محاسبه جای خالی مانده
                res.Seat -= await _context
                            .TicketDomesticFlights
                            .Include(tf => tf.Reservation)
                            .CountAsync(tf =>
                                !tf.IsRemoved &&
                                tf.ReturnedId == null &&
                                tf.Reservation.FlightId == res.DomesticFlightId &&
                                tf.Reservation.TransactionId != null //حتما اون هایی که پرداخت داشتن
                            );
                ////دریافت قوانین استرداد
                //res.ResultTicketRefundRules = await _context
                //           .FlightTicketRefundRules
                //           .Include(r => r.GroupRules)
                //           .ThenInclude(r => r.Flights.Where(fl => fl.Id == res.FlightId))
                //           .Where(r =>
                //               !r.IsRemoved &&
                //               !r.GroupRules.IsRemoved
                //           )
                //           .Select(r => new ResultTicketRefundRulesDto()
                //           {
                //               DeductibleAmount = r.DeductibleAmount,
                //               Description = r.Description,
                //               EndHour = r.EndHour,
                //               End_AfterIssuanceTicket = r.End_AfterIssuanceTicket,
                //               End_BeforeFlight = r.End_BeforeFlight,
                //               IsPercent = r.IsPercent,
                //               StartHour = r.StartHour,
                //               Start_AfterIssuanceTicket = r.Start_AfterIssuanceTicket,
                //               Start_BeforeFlight = r.Start_BeforeFlight,
                //               Title = r.Title
                //           }).ToListAsync();


                return new ResultDto<ResultDomesticFlightInfoService>()
                {
                    IsSuccess = true,
                    Data = res,
                    Message = "دریافت پرواز با موفقیت انجام شد"
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<ResultDomesticFlightInfoService>()
                {
                    IsSuccess = false,
                    Message = "خطا در دریافت اطلاعات",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestDomesticFlightInfoService
    {
        public long FlightId { get; set; }
    }
    public class ResultDomesticFlightInfoService
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
  
}
