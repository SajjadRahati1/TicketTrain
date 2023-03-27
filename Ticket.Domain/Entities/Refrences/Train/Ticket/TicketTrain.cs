using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Train.Ticket
{
    /// <summary>
    /// بلیط قطار
    /// </summary>
    public class TicketTrain : BaseEntity
    {

        public Passenger Passenger { get; set; }
        public SeatOrBed SeatOrBed { get; set; }

        public TicketTrainReturned? Returned { get; set; }
        public long? ReturnedId { get; set; }

        /*/// <summary>
        /// قیمت
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// کد ساخته شده
        /// </summary>
        public string TrackingCode { get; set; }*/

    }
}

