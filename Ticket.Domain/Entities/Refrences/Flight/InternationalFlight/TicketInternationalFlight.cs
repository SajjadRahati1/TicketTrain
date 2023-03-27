using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Flight.InternationalFlight
{
    /// <summary>
    /// بلیط ها به ازای هر مسافر
    /// <see cref="Users.Passenger"/>
    /// </summary>
    public class TicketInternationalFlight : BaseEntity
    {
        public string TicketNumber { get; set; }
        public long PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public TicketInternationalFlightReservation Reservation { get; set; }


        public TicketInternationalFlightReturned? Returned { get; set; }
        public long? ReturnedId { get; set; }

    }
}
