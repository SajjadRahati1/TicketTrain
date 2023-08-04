using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;
using Ticket.Domain.Enums;

namespace Ticket.Application.Services.Users.Commands
{
    public interface IAddPassengerService : IPublicService<RequestAddPassengerDto, long> { }
    public class AddPassengerService : IAddPassengerService
    {
        private readonly IDbContext _context;

        public AddPassengerService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<long>> Execute(RequestAddPassengerDto request)
        {
            try
            {
                if (request.BirthDte.IsNullOrEmpty())
                    return new ResultDto<long>()
                    {
                        IsSuccess = false,
                        Message = "فیلد تاریخ تولد اجباری است",
                        MessageType = MessageType.Warning
                    };
                var birthDate = request.BirthDte.ToMiladi();
                if (birthDate == null)
                    return new ResultDto<long>()
                    {
                        IsSuccess = false,
                        Message = "فیلد تاریخ تولد وارد شده معتبر نمیباشد",
                        MessageType = MessageType.Warning
                    };
                var person = new Person
                {
                    BirthDate = birthDate ?? DateTime.MinValue,
                    EmailAddress = request.EmailAddress,
                    FirstName = request.FirstName,
                    Gender = request.Gender ? Gender.Man : Gender.Woman,
                    IsRemoved = false,
                    LastName = request.LastName,
                    NationalCode = request.NationalCode,
                    PhoneNumber = request.PhoneNumber
                };
                var passenger = new Passenger()
                {
                    CountryBirthId = request.CountryBirthId,
                    En_FirstName = request.En_FirstName,
                    En_LastName = request.En_LastName,
                    ExpireDatePassport = request.ExpireDatePassport,
                    Person = person,
                    UserId = request.UserId
                };
                _context.People.Add(person);
                _context.Passengers.Add(passenger);
                var res = await  _context.SaveChangesAsync();
                if (res > 0)
                {
                    return new ResultDto<long>()
                    {
                        IsSuccess = true,
                        Data = passenger.Id,
                        Message = "مسافر جدید با موفقیت ثبت شد"
                    };
                }
                return new ResultDto<long>()
                {
                    IsSuccess = false,
                    Message = "مشکلی ناشناخته در ثبت اطلاعات رخ داده است",
                    MessageType = MessageType.Error
                };
            }
            catch (Exception)
            {
                return new ResultDto<long>()
                {
                    IsSuccess = false,
                    Message = "مشکلی شناخته شده در ثبت اطلاعات رخ داده است",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestAddPassengerDto
    {
        public long UserId { get; set; }
        public string En_FirstName { get; set; }
        public string En_LastName { get; set; }
        /// <summary>
        /// تاریخ اتمام شماره پاسپورت
        /// </summary>
        public DateTime ExpireDatePassport { get; set; }
        /// <summary>
        /// کشور محل تولد
        /// </summary>
        public long CountryBirthId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string BirthDte { get; set; }
        public bool Gender { get; set; }
    }
}
