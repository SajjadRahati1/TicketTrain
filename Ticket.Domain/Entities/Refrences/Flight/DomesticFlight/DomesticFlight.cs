using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight.DomesticFlight
{
    public class DomesticFlight:BaseEntity
    {
        public long FlightId { get; set; }
        public Flight Flight { get; set; }

        public List<TicketDomesticFlightReservation> Reservations { get; set; }
    }
}
