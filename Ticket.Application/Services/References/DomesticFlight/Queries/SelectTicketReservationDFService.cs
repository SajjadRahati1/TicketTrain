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
    public interface ISelectTicketReservationDFService : IPublicService<RequestSelectTicketReservationDFDto, List<ResultSelectTicketReservationDFDto>>
    {

    }
    public class SelectTicketReservationDFService : ISelectTicketReservationDFService
    {
        private readonly IDbContext _context;

        public SelectTicketReservationDFService(IDbContext context)
        {
            _context = context;
        }


        public async Task<ResultDto<List<ResultSelectTicketReservationDFDto>>> Execute(RequestSelectTicketReservationDFDto request)
        {
            try
            {
                var r = request;
                var res = await
                    _context
                    .TicketDomesticFlightReservations
                    .Include(r => r.User)
                    .ThenInclude(r => r.Person)
                    .Include(r => r.Flight)
                    .ThenInclude(df => df.Flight)
                    .ThenInclude(f => f.DestinationTerminal)
                    .ThenInclude(dt => dt.City)
                    .Include(r => r.Flight)
                    .ThenInclude(df => df.Flight)
                    .ThenInclude(f => f.OriginTerminal)
                    .ThenInclude(dt => dt.City)
                    .Where(f =>
                       
                        (r.TicketReservationId == null || r.TicketReservationId == f.Id)
                        &&
                        (r.UserId == null || r.UserId == f.UserId)
                        &&
                        (r.DomesticFlightId == null || r.DomesticFlightId == f.FlightId)
                        &&
                        (r.TransactionId == null || r.TransactionId == f.TransactionId)
                        &&
                        (r.FlightId == null || r.FlightId == f.Flight.FlightId)
                        &&
                        (r.IsRemoved == null || r.IsRemoved == f.IsRemoved)
                        &&
                        (
                            r.SearchText == null ||
                            (f.TicketNumber ?? "").Contains(r.SearchText) ||
                            (f.OrderNumber ?? "").Contains(r.SearchText) ||
                            (f.TicketNumber??"").Contains(r.SearchText) ||
                            (f.User.PhoneNumber ?? "").Contains(r.SearchText) ||
                            (f.User.UserName ?? "").Contains(r.SearchText) ||
                            (f.User.Person.FirstName + " " + f.User.Person.LastName).Contains(r.SearchText) ||
                            (f.User.Person.NationalCode??"").Contains(r.SearchText)

                        )
                    )
                    .ToPaged(request.Page, request.PageSize, out int count)
                    .Select(f => new ResultSelectTicketReservationDFDto()
                    {
                        Id = f.Id,
                        IsRemoved = f.IsRemoved,
                        RemoveDateTime = f.RemoveTime,
                        Flight = new ResultSelectTicketDFlightDto()
                        {
                            FlightNumber = f.Flight.Flight.FlightNumber,
                            FromCity = f.Flight.Flight.OriginTerminal.City.Name,
                            ToCity = f.Flight.Flight.DestinationTerminal.City.Name,
                            MovingDate = f.Flight.Flight.StartMoving

                        },
                        User = new ResultSelectTicketDFUserDto()
                        {
                            FullNameFa = f.User.Person.FirstName+" "+ f.User.Person.LastName,
                            NationalCode = f.User.Person.NationalCode,
                            PhoneNumber = f.User.Person.PhoneNumber,
                            UserName = f.User.UserName
                        },
                        OrderNumber =f.OrderNumber,
                        TicketNumber =f.TicketNumber,
                        TicketsCount =f.Tickets.Count()
                        

                    }).ToListAsync();

                return new ResultDto<List<ResultSelectTicketReservationDFDto>>()
                {
                    IsSuccess = true,
                    OutCount = count,
                    Data = res
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<List<ResultSelectTicketReservationDFDto>>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.Error
                };
            }
        }

       
    }
    public class RequestSelectTicketReservationDFDto
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
    public class ResultSelectTicketReservationDFDto
    {
        public long Id { get; set; }
       public ResultSelectTicketDFUserDto User { get; set; }
        public ResultSelectTicketDFlightDto Flight { get; set; }

        public string OrderNumber { get; set; }
        public string TicketNumber { get; set; }
        public int TicketsCount { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemoveDateTime { get; set; }
    }
   
}


