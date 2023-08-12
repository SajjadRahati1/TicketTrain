namespace EndPoint.Site.Models.Dto.Account
{
    public class TransactionDto
    {
        public long? Id { get; set; }
        public decimal Amount { get; set; }
        /// <summary>
        /// آیا پرداختی است یا دریافتی
        /// </summary>
        public bool IsPaid { get; set; }
        /// <summary>
        /// عملیات به درستی به اتمام رسیده و پرداخت شده است
        /// </summary>
        public bool IsFinished { get; set; }


        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public string? PaidDate { get; set; }

        public string? Title { get; set; }



        /// <summary>
        ///نوع را مشخص میکند برای مثال 
        ///پرداخت برای بلیط هواپیما است
        ///پس باید در رفرنس آیدی، آیدی بلیط های دریافتی باشد
        /// </summary>
        public string? ReferenceType { get; set; }

        public long UserId { get; set; }
        public string? UserName { get; set; }

    }
}
