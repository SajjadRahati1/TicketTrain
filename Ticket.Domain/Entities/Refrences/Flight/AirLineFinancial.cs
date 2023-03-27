using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// اطلاعات مالی ایرلاین
    /// </summary>
    public class AirLineFinancial : BaseEntitySimple<int>
    {
        public int AirLineId { get; set; }
        public AirLine AirLine { get; set; }


        /// <summary>
        /// کد اقتصادی
        /// </summary>
        public string EnConomicCode { get; set; }
        /// <summary>
        ///شناسه ملی
        /// </summary>
        public string NationalId { get; set; }
        /// <summary>
        ///شماره حساب
        /// </summary>
        public string AccountNumber { get; set; }
        public long BankId { get; set; }
        public Bank Bank { get; set; }
        /// <summary>
        ///شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }

        public string SalesReportLink { get; set; }

    }


}
//کمپانی رو هم بنویس