using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public interface IAddEditTicketDFService : IPublicService<RequestAddEditTicketDFDto>
    {

    }
    /// <summary>
    /// افزودن یا ویرایش و یا حذف مسافر از لیست مسافران فرد در سفر با هواپیمای داخلی
    /// </summary>
    public class AddEditTicketDFService : IAddEditTicketDFService
    {

        private readonly IDbContext _context;
        public AddEditTicketDFService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(RequestAddEditTicketDFDto request)
        {
            try
            {
                request.Id = request.Id == 0 ? null : request.Id;
                TicketDomesticFlight? ticket;
                if (request.Id != null)
                    ticket = new TicketDomesticFlight()
                    {
                        PassengerId = request.PassengerId,
                        TicketNumber = DateTime.Now.Ticks.ToString()
                    };
                else
                {
                    ticket = await
                        _context
                        .TicketDomesticFlights
                        .FirstOrDefaultAsync(f => f.Id == request.Id);
                    if (ticket == null)
                        return new ResultDto()
                        {
                            IsSuccess = false,
                            Message = "مسافر مد نظر یافت نشد",
                            MessageType = MessageType.Error
                        };

                    ticket.IsRemoved = request.IsRemoved;
                    ticket.PassengerId = request.PassengerId;
                }
                var res = await _context.SaveChangesAsync();

                if (res < 1)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "متاسفانه سفارش شما ثبت نشد",
                        MessageType = MessageType.Error
                    };
                }

                return new ResultDto()
                {
                    IsSuccess = true,
                    
                };

            }
            catch (Exception ex)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.BadRequest
                };
            }

        }
    }
    public class RequestAddEditTicketDFDto
    {
        public long? Id { get; set; }
        //public string? TicketNumber { get; set; }
        public long PassengerId { get; set; }
        public bool IsRemoved { get; set; }
    }



}
