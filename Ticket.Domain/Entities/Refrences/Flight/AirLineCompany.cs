using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// شرکت هواپیمایی
    /// /شرکت سازنده هواپیما
    /// </summary>
    public class AirLineCompany : BaseEntitySimple
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string SiteUrl { get; set; }

    }


}
//کمپانی رو هم بنویس