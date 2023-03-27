using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences;

namespace Ticket.Domain.Entities.Users
{
    /// <summary>
    /// تراکنش ها
    /// </summary>
    public class Transaction : BaseEntity
    {
        /// <summary>
        /// مبلغ
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// آیا پرداختی است یا دریافتی
        /// </summary>
        public bool IsPaid { get; set; }
        public Wallet Wallet { get; set; }
        public long WalletId { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime PaidDate { get; set; }
        /// <summary>
        /// عنوانی که باید بک اند پر کند
        /// </summary>
        public string Title { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// کد پیگیری بانکی
        /// </summary>
        public string TrackingCodeBank { get; set; }

        /// <summary>
        /// مبلغ بابت چه چیزی پرداخت یا دریافت شده است
        /// </summary>
        public long RefrenceID { get; set; }
        /// <summary>
        ///نوع را مشخص میکند برای مثال 
        ///پرداخت برای بلیط هواپیما است
        ///پس باید در رفرنس آیدی، آیدی بلیط های دریافتی باشد
        /// </summary>
        public int RefrenceTypeID { get; set; }
        public RefrenceType RefrenceType { get; set; }

        /// <summary>
        /// اگر تخفیف دریافت کرده است در اینجا مشخص میشود
        /// </summary>
        public List<UsedDiscount> Discounts { get; set; }
        

        //نکته : زمانی که فرد بخواهد بلیط را بازگرداند و وجه دریافت کند به صورت خودکار باید به کیف پول
        //فرد اضافه شود در صورتی که خواست میتواند برداشت از کیف پول داشته باشد
        //در حالت برداشت از کیف پول باید به صورت زیر باشد:
        //IsPaied=true;Title="برداشت از کیف پول";RefrenceTypeId=نوع شماره کارت خود فرد;RefrenceId=شماره کارت فرد
    }
}
