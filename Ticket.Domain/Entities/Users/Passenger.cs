using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences.Bus.Ticket;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
using Ticket.Domain.Entities.Refrences.Flight.InternationalFlight;

namespace Ticket.Domain.Entities.Users
{
    public class Passenger : BaseEntity
    {
       
        /// <summary>
        /// اطلاعات پایه
        /// </summary>
        public long PersonId { get; set; }
        public Person Person { get; set; }

        public string? En_FirstName { get; set; }
        public string? En_LastName { get; set; }
        public string? PassportNumber { get; set; }
        /// <summary>
        /// تاریخ اتمام شماره پاسپورت
        /// </summary>
        public DateTime? ExpireDatePassport { get; set; }
        /// <summary>
        /// کشور محل تولد
        /// </summary>
        public long? CountryBirthId { get; set; }

        #region بلیط های مسافر
        public List<TicketDomesticFlight> TicketDomesticFlights { get; set; }
        public List<TicketInternationalFlight> TicketInternationalFlights { get; set; }
        public List<TicketBusReservation> TicketBusReservations { get; set; }
        #endregion

        public User User { get; set; }
        public long UserId { get; set; }
    }
}
