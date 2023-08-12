using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Enums;

namespace Ticket.Application.Services.Passengers.Queries
{
    public interface IPassengerInfoService : IPublicService<long, ResultPassengerInfoDto>
    {

    }

    public class PassengerInfoService : IPassengerInfoService
    {

        private readonly IDbContext _context;
        public PassengerInfoService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<ResultPassengerInfoDto>> Execute(long request)
        {
            try
            {
                var p =
                    await
                    _context
                    .Passengers
                    .Include(p => p.Person)
                    .FirstOrDefaultAsync(p => p.Id == request);
                if (p == null)
                    return new ResultDto<ResultPassengerInfoDto>
                    {
                        IsSuccess = false,
                        Message = "مسافر شما یافت نشد",
                        MessageType = MessageType.Error
                    };
                var pp = p.Person;
                var res = new ResultPassengerInfoDto
                {
                    En_FirstName = p.En_FirstName,
                    En_LastName = p.En_LastName,
                    CountryBirthId = p.CountryBirthId,
                    ExpireDatePassport = p.ExpireDatePassport,
                    EmailAddress = pp.EmailAddress,
                    FirstName = pp.FirstName,
                    LastName = pp.LastName,
                    NationalCode = pp.NationalCode,
                    Gender = pp.Gender == Gender.Man,
                    PhoneNumber = pp.PhoneNumber,
                    BirthDte = pp.BirthDate.ToShamsi()
                };

                if (res == null)
                {
                    return new ResultDto<ResultPassengerInfoDto>()
                    {
                        IsSuccess = false,
                        Message = "مسافر یافت نشد",
                        MessageType = MessageType.Error
                    };
                }

                return new ResultDto<ResultPassengerInfoDto>()
                {
                    IsSuccess = true,
                    Data = res
                };

            }
            catch (Exception ex)
            {
                return new ResultDto<ResultPassengerInfoDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    MessageType = MessageType.BadRequest
                };
            }

        }
    }
    public class ResultPassengerInfoDto
    {
        public string En_FirstName { get; set; }
        public string En_LastName { get; set; }
        /// <summary>
        /// تاریخ اتمام شماره پاسپورت
        /// </summary>
        public DateTime? ExpireDatePassport { get; set; }
        /// <summary>
        /// کشور محل تولد
        /// </summary>
        public long? CountryBirthId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string BirthDte { get; set; }
        public bool Gender { get; set; }
    }
}
