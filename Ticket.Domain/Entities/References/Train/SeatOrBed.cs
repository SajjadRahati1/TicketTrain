using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    /// صندلی یا تخت کوپه قطار
    /// </summary>
    public class SeatOrBed : BaseEntity
    {
        public int Number { get; set; }

        public Compartment Compartment { get; set; }
        public long CompartmentId { get; set; }

        /// <summary>
        /// در کدام قسمت کوپه است
        /// </summary>
        public string Location { get; set; }
    }
}

