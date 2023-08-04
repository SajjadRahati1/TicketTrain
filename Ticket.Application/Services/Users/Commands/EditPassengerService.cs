using Ticket.Application.Interfaces.Contexts;
using Ticket.Application.Interfaces.Services;
using Ticket.Common;
using Ticket.Common.Dto;
using Ticket.Domain.Entities.Users;
using Ticket.Domain.Enums;

namespace Ticket.Application.Services.Users.Commands
{
    public interface IEditPassengerService : IPublicService<RequestEditPassengerDto, long> { }
    public class EditPassengerService : IEditPassengerService
    {
        private readonly IDbContext _context;

        public EditPassengerService(IDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<long>> Execute(RequestEditPassengerDto request)
        {
            try
            {
                var passenger = _context.Passengers.FirstOrDefault(p => p.Id == request.PassengerId);
                if (passenger == null)
                    return new ResultDto<long>()
                    {
                        IsSuccess = false,
                        Message = "مسافر مدنظر شما یافت نشد",
                        MessageType = MessageType.Warning
                    };
                var person = _context.People.FirstOrDefault(p => p.Id == passenger.PersonId);
                if (person == null)
                    return new ResultDto<long>()
                    {
                        IsSuccess = false,
                        Message = "مسافر مدنظر شما یافت نشد",
                        MessageType = MessageType.Warning
                    };
                var birthDate = request?.BirthDte?.ToMiladi();

                if (request.ExpireDatePassport != null)
                    passenger.ExpireDatePassport = request.ExpireDatePassport ?? passenger.ExpireDatePassport;
                if (request.CountryBirthId != null)
                    passenger.CountryBirthId = request.CountryBirthId ?? passenger.CountryBirthId;
                if (!request.En_FirstName.IsNullOrEmpty())
                    passenger.En_FirstName = request.En_FirstName;
                if (!request.En_LastName.IsNullOrEmpty())
                    passenger.En_LastName = request.En_LastName;
                if (request.IsRemoved != null)
                    passenger.IsRemoved = request.IsRemoved ?? false;



                if (!request.BirthDte.IsNullOrEmpty() && birthDate != null)
                    person.BirthDate = birthDate ?? person.BirthDate;
                if (!request.EmailAddress.IsNullOrEmpty())
                    person.EmailAddress = request.EmailAddress ?? person.EmailAddress;
                if (!request.FirstName.IsNullOrEmpty())
                    person.FirstName = request.FirstName ?? person.FirstName;
                if (!request.LastName.IsNullOrEmpty())
                    person.LastName = request.LastName ?? person.LastName;
                if (!request.NationalCode.IsNullOrEmpty())
                    person.NationalCode = request.NationalCode ?? person.NationalCode;
                if (!request.PhoneNumber.IsNullOrEmpty())
                    person.PhoneNumber = request.PhoneNumber ?? person.PhoneNumber;
                if (request.Gender != null)
                    person.Gender = request.Gender == true ? Gender.Man : Gender.Woman;
               //if (request.IsRemoved != null)
               //     person.IsRemoved = request.IsRemoved??false;
               

                var res = await _context.SaveChangesAsync();
                if (res > 0)
                {
                    return new ResultDto<long>()
                    {
                        IsSuccess = true,
                        Data = passenger.Id,
                        Message = "مسافر شما با موفقیت ویرایش شد"
                    };
                }
                return new ResultDto<long>()
                {
                    IsSuccess = false,
                    Message = "مشکلی ناشناخته در ویرایش اطلاعات رخ داده است",
                    MessageType = MessageType.Error
                };
            }
            catch (Exception)
            {
                return new ResultDto<long>()
                {
                    IsSuccess = false,
                    Message = "مشکلی شناخته شده در ویرایش اطلاعات رخ داده است",
                    MessageType = MessageType.Error
                };
            }
        }
    }
    public class RequestEditPassengerDto
    {
        public long PassengerId { get; set; }
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
        public bool? Gender { get; set; }
        public bool? IsRemoved { get; set; }
    }
}
