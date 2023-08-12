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

namespace Ticket.Application.Services.References.DomesticFlight.Queries
{
    public interface ISelectTicketDFService : IPublicService<RequestSelectTicketDFDto, List<ResultSelectTicketDFDto>>
    {

    }
    public class SelectTicketDFService : ISelectTicketDFService
    {
        private readonly IDbContext _context;

        public SelectTicketDFService(IDbContext context)
        {
            _context = context;
        }

        async Task<ResultDto<List<ResultSelectTicketDFDto>>> IPublicService<RequestSelectTicketDFDto, List<ResultSelectTicketDFDto>>.Execute(RequestSelectTicketDFDto request)
        {
            try
            {
                var r = request;
                var res = await
                    _context
                    .TicketDomesticFlights
                    .Include(t => t.Passenger)
                    .ThenInclude(t => t.Person)
                    .Include(t => t.Returned)
                    .Include(t => t.Reservation)
                    .ThenInclude(r => r.User)
                    .ThenInclude(r => r.Person)
                    .Include(t => t.Reservation)
                    .ThenInclude(r => r.Flight)
                    .ThenInclude(df => df.Flight)
                    .ThenInclude(f => f.DestinationTerminal)
                    .ThenInclude(dt => dt.City)
                    .Include(t => t.Reservation)
                    .ThenInclude(r => r.Flight)
                    .ThenInclude(df => df.Flight)
                    .ThenInclude(f => f.OriginTerminal)
                    .ThenInclude(dt => dt.City)
                    .Where(f =>
                        (r.PassengerId == null || r.PassengerId == f.PassengerId)
                        &&
                        (r.TicketReservationId == null || r.TicketReservationId == f.ReservationId)
                        &&
                        (r.UserId == null || r.UserId == f.Reservation.UserId)
                        &&
                        (r.DomesticFlightId == null || r.DomesticFlightId == f.Reservation.FlightId)
                        &&
                        (r.TransactionId == null || r.TransactionId == f.Reservation.TransactionId)
                        &&
                        (r.FlightId == null || r.FlightId == f.Reservation.Flight.FlightId)
                        &&
                        (r.IsRemoved == null || r.IsRemoved == f.IsRemoved)
                        &&
                        (r.IsReturned == null || r.IsReturned.Value ? f.ReturnedId != null : f.ReturnedId == null)
                        &&
                        (
                            r.SearchText == null ||
                            (f.TicketNumber).Contains(r.SearchText) ||
                            (f.Passenger.PassportNumber).Contains(r.SearchText) ||
                            (f.Passenger.En_FirstName + " " + f.Passenger.En_LastName).Contains(r.SearchText) ||
                            (f.Passenger.Person.FirstName + " " + f.Passenger.Person.LastName).Contains(r.SearchText) ||
                            (f.Passenger.Person.NationalCode).Contains(r.SearchText) ||
                            (f.Reservation.OrderNumber).Contains(r.SearchText) ||
                            (f.Reservation.TicketNumber).Contains(r.SearchText) ||
                            (f.Reservation.User.PhoneNumber).Contains(r.SearchText) ||
                            (f.Reservation.User.UserName).Contains(r.SearchText) ||
                            (f.Reservation.User.Person.FirstName + " " + f.Reservation.User.Person.LastName).Contains(r.SearchText) ||
                            (f.Reservation.User.Person.NationalCode).Contains(r.SearchText)

                        )
                    )
                    .ToPaged(request.Page, request.PageSize, out int count)
                    .Select(f => new ResultSelectTicketDFDto()
                    {
                        Id = f.Id,
                        IsRemoved = f.IsRemoved,
                        RemoveDateTime = f.RemoveTime,
                        IsReturned = f.ReturnedId!=null,
                        Flight = new ResultSelectTicketDFlightDto()
                        {
                            FlightNumber = f.Reservation.Flight.Flight.FlightNumber,
                            FromCity = f.Reservation.Flight.Flight.OriginTerminal.City.Name,
                            ToCity = f.Reservation.Flight.Flight.DestinationTerminal.City.Name,
                            MovingDate = f.Reservation.Flight.Flight.StartMoving

                        },
                        User = new ResultSelectTicketDFUserDto()
                        {
                            FullNameFa = f.Reservation.User.Person.FirstName+" "+ f.Reservation.User.Person.LastName,
                            NationalCode = f.Reservation.User.Person.NationalCode,
                            PhoneNumber = f.Reservation.User.Person.PhoneNumber,
                            UserName = f.Reservation.User.UserName
                        },
                        Passenger = new ResultSelectTicketDFPassengerDto()
                        {
                            FullNameFa = f.Passenger.Person.FirstName + " " + f.Passenger.Person.LastName,
                            FullNameEn = f.Passenger.En_FirstName + " " + f.Passenger.En_LastName,
                            NationalCode = f.Passenger.Person.NationalCode
                        }
                        

                    }).ToListAsync();

                return new ResultDto<List<ResultSelectTicketDFDto>>()
                {
                    IsSuccess = true,
                    OutCount = count,
                    Data = res
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<List<ResultSelectTicketDFDto>>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestSelectTicketDFDto
    {
        public long? UserId { get; set; }
        public long? PassengerId { get; set; }
        public long? TransactionId { get; set; }
        public long? DomesticFlightId { get; set; }
        public long? FlightId { get; set; }
        public long? TicketReservationId { get; set; }
        public bool? IsRemoved { get; set; }
        public bool? IsReturned { get; set; }
        public string SearchText { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
    public class ResultSelectTicketDFDto
    {
        public long Id { get; set; }
        public ResultSelectTicketDFPassengerDto Passenger { get; set; }
        public ResultSelectTicketDFUserDto User { get; set; }
        public ResultSelectTicketDFlightDto Flight { get; set; }

        public bool IsReturned { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemoveDateTime { get; set; }
    }
    public class ResultSelectTicketDFPassengerDto
    {
        public string FullNameFa { get; set; }
        public string FullNameEn { get; set; }
        public string NationalCode { get; set; }
    }
    public class ResultSelectTicketDFUserDto : ResultSelectTicketDFPassengerDto
    {
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
    public class ResultSelectTicketDFlightDto
    {
        public string FlightNumber { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime MovingDate { get; set; }
    }
}


