using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Bus.Ticket
{
    /// <summary>
    /// مرجوع کردن بلیط اتوبوس
    /// </summary>
    public class TicketBusReturned : BaseEntitySimple
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
