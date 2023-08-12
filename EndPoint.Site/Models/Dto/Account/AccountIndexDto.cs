using Ticket.Application.Services.References.DomesticFlight.Queries;
using Ticket.Domain.Enums;

namespace EndPoint.Site.Models.Dto.Account
{
    public class AccountIndexDto
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Money { get; set; }
        public bool PhoneNumberVerified { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailVerified { get; set; }

        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string BrithDate { get; set; }
    }
}
