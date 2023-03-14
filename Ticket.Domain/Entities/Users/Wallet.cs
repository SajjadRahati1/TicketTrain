using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Users
{
    /// <summary>
    /// کیف پول
    /// </summary>
    public class Wallet : BaseEntitySimple
    {
        public User User { get; set; }
        /// <summary>
        /// تراکنش های شخص و کیف پول
        /// </summary>
        public List<Transaction> Transactions { get; set; }

        /// <summary>
        /// مبلغ باقی مانده در کیف پول
        /// </summary>
        public decimal Balance { get; set; }
    }
}
