using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences;

namespace Ticket.Domain.Entities.Users
{
    /// <summary>
    /// تخفیف
    /// </summary>
    public class Discount : BaseEntitySimple
    {
        public string Name { get; set; }
        /// <summary>
        /// تخفیف به صورت درصدی باشد
        /// </summary>
        public bool IsPrecent { get; set; }

        /// <summary>
        /// مقداری که باید تخفیف داده شود به صورت درصد و یا به همان مبلغ تعیین شده
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// ماکسیمم تعداد استفاده
        /// </summary>
        public int? MaxUse { get; set; }

        /// <summary>
        /// اگر به صورت درصدی بود حداکثر مبلغ تخفیف چقدر باشد
        /// </summary>
        public decimal? MaxDiscount { get; set; }

        /// <summary>
        /// تاریخ شروع به استفاده
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان استفاده
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// در چه زمینه ای هست این تخفیف
        /// (اختیاری)
        /// </summary>
        public RefrenceType? RefrenceType { get; set; }
        public int? RefrenceTypeID { get; set; }
        /// <summary>
        /// برای یک سفر-پرواز-یا .. خاص است
        /// </summary>
        public long? RefrenceId { get; set;}

        /// <summary>
        /// کد تخفیف
        /// در صورت وجود داشتن کد تخفیف باید به صورت منحصر به فرد باشد
        /// </summary>
        public string? DiscountCode { get; set; }

        /// <summary>
        /// هرچقدر اهمیت بیشتر باشد این تخفیف در اولویت بیشتری قرار گرفته خواهد شد
        /// برای مثال زمانی که چند تخفیف را کاربر استفاده میکند با کمک این مقدار مشخص میشود کدام یکی باید ابتدا اعمال شود
        /// </summary>
        public int Important { get; set; }

        /// <summary>
        /// در تخفیف های چند تایی بشود اعمال کرد
        /// اگر این گزینه فعال نباشد و این تخفیف روی بلیطی باشد دیگر نمیتوان که تخفیف دیگری را روی خرید اعمال کرد
        /// نکته : این گزینه زمانی کارا است که به صورت کد تخفیف نباشد و به صورت خودکار روی بلیط اعمال شده باشد
        /// </summary>
        public bool IsDoubleDiscount { get; set; } = true;

        /// <summary>
        /// استفاده شده این تخفیف
        /// </summary>
        public List<UsedDiscount> UsedDiscounts { get; set; }
    }
}
