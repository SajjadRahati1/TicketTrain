using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    public class CompanyServiceProviders : BaseEntitySimple
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Site { get; set; }
        public string UrlImage { get; set; }
        public DateOnly CreatedDate { get; set; }

    }

}
//کمپانی رو هم بنویس
