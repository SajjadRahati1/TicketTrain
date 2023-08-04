using Microsoft.AspNetCore.Identity;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Application.Services.References.DomesticFlight.Queries;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Refrences.Flight;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
using Ticket.Domain.Enums;

namespace Ticket.Application.Services.Passengers.Queries
{
    public interface IAddTicketDFReservationService : IPublicService<RequestAddTicketDFReservationDto, ResultAddTicketDFReservationDto>
    {

    }

    public class AddTicketDFReservationService : IAddTicketDFReservationService
    {

        private readonly IDbContext _context;
        public AddTicketDFReservationService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultAddTicketDFReservationDto>> Execute(RequestAddTicketDFReservationDto request)
        {
            try
            {
                var dfService = new DomesticFlightInfoService(_context);
                var flight = await dfService.Execute(new RequestDomesticFlightInfoService() { FlightId = request.FlightId });
                if (!flight.IsSuccess)
                    return new ResultDto<ResultAddTicketDFReservationDto>
                    {
                        IsSuccess = flight.IsSuccess,
                        Message = flight.Message,
                        MessageType = flight.MessageType
                    };

                var fl = flight.Data;
                var tickets = request.Passengers.Select(p => new TicketDomesticFlight()
                {
                    PassengerId = p,
                    IsRemoved = false,
                    //ساخت آیدنتیتی برای این مقدار
                    TicketNumber = (DateTime.UtcNow.Ticks + "" + p)
                }).ToList();
                /*
                 fl.OriginName+
                                    "_"+fl.DestinationName+
                                    "_"+fl.FlightNumber+
                                    "_"+fl.AirlineCode+
                                    "_"+request.UserId
                 */
                var orderNumber = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                var ticketReservation = new TicketDomesticFlightReservation()
                {
                    UserId = request.UserId,
                    FlightId = request.FlightId,
                    OrderNumber = orderNumber.Substring(0, 15),
                    Tickets = tickets,
                    TicketNumber = DateTime.Now.Ticks.ToString(),
                    SendOtherInformationToPhoneNumber = request.SendOtherInformationToPhoneNumber,
                    SendOtherInformationToEmail = request.SendOtherInformationToEmail
                };
                var res = await _context.SaveChangesAsync();
                if (res < 1)
                {
                    return new ResultDto<ResultAddTicketDFReservationDto>()
                    {
                        IsSuccess = false,
                        Message = "متاسفانه سفارش شما ثبت نشد",
                        MessageType = MessageType.Error
                    };
                }

                return new ResultDto<ResultAddTicketDFReservationDto>()
                {
                    IsSuccess = true,
                    Data = new ResultAddTicketDFReservationDto()
                    {
                        OrderNumber = ticketReservation.OrderNumber,
                        TicketNumber = ticketReservation.TicketNumber,
                        Passengers = ticketReservation.Tickets.Select(t => new ResultAddTicketDfReservationPassengerDto()
                        {
                            PassengerId = t.PassengerId,
                            TicketNumber = t.TicketNumber,
                        }).ToList()
                    }
                };

            }
            catch (Exception ex)
            {
                return new ResultDto<ResultAddTicketDFReservationDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.BadRequest
                };
            }

        }
    }
    public class RequestAddTicketDFReservationDto
    {
        public long FlightId { get; set; }
        public long UserId { get; set; }
        /// <summary>
        /// اطلاعات بلیط و اطلاع‌رسانی بعدی به این ادرس ارسال می‌شود.
        /// </summary>
        public string? SendOtherInformationToPhoneNumber { get; set; }
        /// <summary>
        /// اطلاعات بلیط و اطلاع‌رسانی بعدی به این ادرس ارسال می‌شود.
        /// </summary>
        public string? SendOtherInformationToEmail { get; set; }
        /// <summary>
        /// لیست مسافر های شخص
        /// </summary>
        public List<long> Passengers { get; set; }
    }
    public class ResultAddTicketDFReservationDto
    {
        public string? TicketNumber { get; set; }
        /// <summary>
        /// این شماره رو خود سایت میسازد
        /// </summary>
        public string? OrderNumber { get; set; }

        public List<ResultAddTicketDfReservationPassengerDto> Passengers { get; set; }
    }
    public class ResultAddTicketDfReservationPassengerDto
    {
        public long PassengerId { get; set; }
        public string? TicketNumber { get; set; }
    }
  
}
