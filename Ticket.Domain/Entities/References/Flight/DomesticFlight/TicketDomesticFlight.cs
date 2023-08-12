using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Flight.DomesticFlight
{
    /// <summary>
    /// بلیط ها به ازای هر مسافر
    /// <see cref="Users.Passenger"/>
    /// </summary>
    public class TicketDomesticFlight : BaseEntity
    {
        public string TicketNumber { get; set; }
        public long PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public TicketDomesticFlightReservation Reservation { get; set; }
        public long ReservationId { get; set; }


        public TicketDomesticFlightReturned? Returned { get; set; }
        public long? ReturnedId { get; set; }

    }
}
