using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    /// ایستگاه قطار
    /// </summary>
    public class TrainStation : BaseEntitySimple
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public long CityId { get; set; }
    }
}

