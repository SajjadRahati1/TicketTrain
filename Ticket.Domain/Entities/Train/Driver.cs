using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Train
{
    public class Driver:BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string Certification { get; set; }
        public List<TrainRoute> TrainRoutes { get; set; }
    }
}

}
