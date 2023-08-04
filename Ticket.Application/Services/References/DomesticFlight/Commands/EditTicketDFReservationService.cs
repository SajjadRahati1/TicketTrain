using Microsoft.EntityFrameworkCore;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Application.Services.References.DomesticFlight.Queries;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;

namespace Ticket.Application.Services.Passengers.Queries
{
    public interface IEditTicketDFReservationService : IPublicService<RequestEditTicketDFReservationDto, ResultEditTicketDFReservationDto>
    {

    }
    public class EditTicketDFReservationService : IEditTicketDFReservationService
    {

        private readonly IDbContext _context;
        public EditTicketDFReservationService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultEditTicketDFReservationDto>> Execute(RequestEditTicketDFReservationDto request)
        {
            try
            {
                request.Id = request.Id == 0 ? null : request.Id;
                request.UserId = request.UserId == 0 ? null : request.UserId;
                if (!request.Id.HasValue && (request.FlightId == 0 || !request.UserId.HasValue))
                    return new ResultDto<ResultEditTicketDFReservationDto>()
                    {
                        IsSuccess = false,
                        Message = "اطلاعات برای ویرایش به درستی وارد نشده اند",
                        MessageType = MessageType.Error
                    };

                var dfService = new DomesticFlightInfoService(_context);
                var flight = await dfService.Execute(new RequestDomesticFlightInfoService() { FlightId = request.FlightId });
                if (!flight.IsSuccess)
                    return new ResultDto<ResultEditTicketDFReservationDto>
                    {
                        IsSuccess = flight.IsSuccess,
                        Message = flight.Message,
                        MessageType = flight.MessageType
                    };

                var fl = flight.Data;

                var orderNumber = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                var ticketReservation = await
                    _context
                    .TicketDomesticFlightReservations
                    .FirstOrDefaultAsync(t =>
                        (request.Id == null || request.Id == t.Id)
                        &&
                        request.UserId == t.UserId
                        &&
                        request.FlightId == t.FlightId
                    );

                ticketReservation.SendOtherInformationToPhoneNumber = request.SendOtherInformationToPhoneNumber;
                ticketReservation.SendOtherInformationToEmail = request.SendOtherInformationToEmail;


                var ticketsAdd = request.AddPassengers.Select(p => new TicketDomesticFlight()
                {
                    PassengerId = p,
                    IsRemoved = false,
                    //ساخت آیدنتیتی برای این مقدار
                    TicketNumber = (DateTime.UtcNow.Ticks + "" + p)
                }).ToList();
                var ticketsRemove = _context.TicketDomesticFlights
                    .Where(f =>
                        !f.IsRemoved &&
                        f.ReservationId == ticketReservation.Id &&
                        request.RemovePassengers.Any(p => p == f.PassengerId)

                    ).ToList();
                ticketsRemove.ForEach(t =>
                {
                    t.IsRemoved = true;
                });

                var res = await _context.SaveChangesAsync();
                if (res < 1)
                {
                    return new ResultDto<ResultEditTicketDFReservationDto>()
                    {
                        IsSuccess = false,
                        Message = "متاسفانه ویرایش شما ثبت نشد",
                        MessageType = MessageType.Error
                    };
                }

                return new ResultDto<ResultEditTicketDFReservationDto>()
                {
                    IsSuccess = true,
                    Data = new ResultEditTicketDFReservationDto()
                    {
                        OrderNumber = ticketReservation.OrderNumber,
                        TicketNumber = ticketReservation.TicketNumber,
                        Passengers = ticketsAdd.Select(t => new ResultEditTicketDfReservationPassengerDto()
                        {
                            PassengerId = t.PassengerId,
                            TicketNumber = t.TicketNumber,
                        }).ToList()
                    }
                };

            }
            catch (Exception ex)
            {
                return new ResultDto<ResultEditTicketDFReservationDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.BadRequest
                };
            }

        }
    }
  
    public class RequestEditTicketDFReservationDto
    {
        public long? Id { get; set; }
        public long FlightId { get; set; }
        public long? UserId { get; set; }
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
        public List<long> AddPassengers { get; set; }
        public List<long> RemovePassengers { get; set; }
    }
    public class ResultEditTicketDFReservationDto
    {
        public string? TicketNumber { get; set; }
        /// <summary>
        /// این شماره رو خود سایت میسازد
        /// </summary>
        public string? OrderNumber { get; set; }

        public List<ResultEditTicketDfReservationPassengerDto> Passengers { get; set; }
    }
    public class ResultEditTicketDfReservationPassengerDto
    {
        public long PassengerId { get; set; }
        public string? TicketNumber { get; set; }
    }
}
