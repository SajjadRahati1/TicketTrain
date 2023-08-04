using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Enums;

namespace Ticket.Application.Services.Passengers.Queries
{
    public interface IPassengersListService : IPublicService<RequestPassnegerListDto, List<ResultPassengerListDto>>
    {

    }

    public class PassengersListService : IPassengersListService
    {

        private readonly IDbContext _context;
        public PassengersListService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<ResultPassengerListDto>>> Execute(RequestPassnegerListDto request)
        {
            try
            {
                if(request.UserId==0)
                    request.UserId=null;
                if (request.SearchText.IsNullOrEmpty())
                    request.SearchText = null;
                
                var result =
                    await
                    _context
                    .Passengers
                    .Include(p => p.Person)
                    .Where(p =>
                        (
                            request.UserId == null ||
                            p.UserId == request.UserId
                         )
                        &&
                        (
                            request.Gender == null ||
                            p.Person.Gender == (request.Gender == true ? Gender.Man : Gender.Woman)
                         )
                        &&
                        (
                            request.SearchText == null ||
                            (p.En_FirstName + " " + p.En_LastName).Contains(request.SearchText) ||
                            (p.Person.FirstName + " " + p.Person.LastName).Contains(request.SearchText) ||
                            p.Person.NationalCode.Contains(request.SearchText) ||
                            p.PassportNumber.Contains(request.SearchText)
                        )
                    )
                    .ToPaged(request.Page, request.PageSize, out int count)
                    .Select(p=>new ResultPassengerListDto()
                    {
                        Id = p.Id,
                        FullName_En = p.En_FirstName + " " + p.En_LastName,
                        FullName_Fa = p.Person.FirstName + " " + p.Person.LastName,
                        Gender = p.Person.Gender == Gender.Man,
                        NationalCode = p.Person.NationalCode,
                        PassportNumber = p.PassportNumber
                    })
                    .ToListAsync();
                
                

                if (result == null)
                {
                    return new ResultDto<List<ResultPassengerListDto>>()
                    {
                        IsSuccess = true,
                        Message = "مسافری یافت نشد",
                        MessageType = MessageType.Info
                    };
                }

                return new ResultDto<List<ResultPassengerListDto>>()
                {
                    IsSuccess = true,
                    Data = result
                };

            }
            catch (Exception ex)
            {
                return new ResultDto<List<ResultPassengerListDto>>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.BadRequest
                };
            }

        }
    }
    public class RequestPassnegerListDto
    {
        public long? UserId { get; set; }
        public string? SearchText { get; set; }
        public bool? Gender { get; set; }
        public int Page { get; set; } =1;
        public int PageSize { get; set; } = 10; 

    }
    public class ResultPassengerListDto
    {
        public long Id { get; set; }
        public string? FullName_Fa { get; set; }
        public string FullName_En { get; set; }
        public bool Gender { get; set; }
        public string NationalCode { get; set; }
        public string PassportNumber { get; set; }
    }
}
