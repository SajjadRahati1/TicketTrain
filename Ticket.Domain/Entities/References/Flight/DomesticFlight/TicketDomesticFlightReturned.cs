using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Financial;

namespace Ticket.Domain.Entities.Refrences.Flight.DomesticFlight
{
    /// <summary>
    /// استرداد و بازگشت بلیط
    /// </summary>
    public class TicketDomesticFlightReturned : BaseEntitySimple
    {
        
        public string ReasonForReturned { get; set; }
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// بازگشت پول به کیف پول کاربر
        /// </summary>
        public Transaction Transaction { get; set; }
        public long TransactionId { get; set; }


    }
}
