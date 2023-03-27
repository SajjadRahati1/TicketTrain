using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences;

namespace Ticket.Domain.Entities.Users
{
    /// <summary>
    /// استفاده شده های یک تخفیف
    /// </summary>
    public class UsedDiscount : BaseEntitySimple
    {
        public Transaction Transaction { get; set; }
        public long TransactionId { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }

        /// <summary>
        /// مبلغ نهایی که تخفیف گرفته است
        /// </summary>
        public decimal GetDiscountCost { get; set; }

        /// <summary>
        /// این تخفیف رو روی چه نوع چیزی گرفته است
        /// </summary>
        public RefrenceType RefrenceType { get; set; }
        public int RefrenceTypeID { get; set; }
        /// <summary>
        /// این تخفیف رو روی چه چیزی گرفته است 
        /// مثلا کدام بلیط قطار
        /// </summary>
        public long RefrenceId { get; set; }

    }
}
