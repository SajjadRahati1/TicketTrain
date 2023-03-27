using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// ترمینال هواپیما
    /// </summary>
    public class AirplaneTerminal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public long CityId { get; set; }
        public City City { get; set; }
    }


}
//کمپانی رو هم بنویس