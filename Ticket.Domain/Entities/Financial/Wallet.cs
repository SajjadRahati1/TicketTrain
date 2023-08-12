using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Financial
{
    /// <summary>
    /// کیف پول
    /// </summary>
    public class Wallet : BaseEntitySimple
    {
       /* public User User { get; set; }
        public long UserId { get; set; }*/
        /// <summary>
        /// تراکنش های شخص و کیف پول
        /// </summary>
        public List<Transaction> Transactions { get; set; }

        /// <summary>
        /// مبلغ باقی مانده در کیف پول
        /// </summary>
        public decimal Balance { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }
    }
}
