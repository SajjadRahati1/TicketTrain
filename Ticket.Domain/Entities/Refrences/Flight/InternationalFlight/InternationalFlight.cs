using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight.InternationalFlight
{

    public class InternationalFlight : BaseEntity
    {
        public long FlightId { get; set; }
        public Flight Flight { get; set; }

        public List<TicketInternationalFlightReservation> Reservations { get; set; }
    }
}
