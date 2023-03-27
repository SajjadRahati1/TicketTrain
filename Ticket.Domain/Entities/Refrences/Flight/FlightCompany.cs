using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// شرکت مسافربری
    /// </summary>
    public class FlightCompany : BaseEntitySimple
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string SiteUrl { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


    }


}
//کمپانی رو هم بنویس