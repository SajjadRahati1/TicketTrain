using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Train.Ticket
{
    /// <summary>
    /// مرجوع کردن بلیط قطار
    /// </summary>
    public class TicketTrainReturned : BaseEntitySimple
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

