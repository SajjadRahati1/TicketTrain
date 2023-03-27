using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// قوانین استرداد بلیط هواپیما
    /// </summary>
    public class FlightTicketRefundRules:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// مبلغ قابل کسر
        /// </summary>
        public decimal DeductibleAmount { get; set; }

        /// <summary>
        /// مبلغ به صورت درصدی در نظر گرفته شود
        /// </summary>
        public bool IsPercent { get; set; }

        /// <summary>
        /// شروع از چه مدت پس از صدور بلیط
        /// </summary>
        public TimeSpan? Start_AfterIssuanceTicket { get; set; }
        /// <summary>
        /// پایان از چه مدت پس از صدور بلیط
        /// </summary>
        public TimeSpan? End_AfterIssuanceTicket { get; set; }
        //مثال : از زمان صدور بلیط تا 4 روز پس از آن مهلت انقضا به این قانون استرداد وجود دارد

        /// <summary>
        /// شروع از چه مدت قبل از پرواز
        /// </summary>
        public TimeSpan? Start_BeforeFlight { get; set; }
        /// <summary>
        /// پایان از چه مدت قبل از پرواز
        /// </summary>
        public TimeSpan? End_BeforeFlight { get; set; }
        //مثال : از 2 روز قبل از پرواز تا 1 روز قبل از پرواز مهلت انقضا به این قانون استرداد وجود دارد

        /// <summary>
        /// در روز استرداد بلیط شروع از چه ساعتی باشد
        /// </summary>
        public short? StartHour { get; set; }
        /// <summary>
        /// در روز استرداد بلیط شروع از چه ساعتی باشد
        /// </summary>
        public short? EndHour { get; set; }
        //مثال : از زمان صدور بلیط تا 12:00 ظهر 1 روز قبل از پرواز
        //مثال : از 12:00 ظهر 1 روز قبل از پرواز تا 4 ساعت قبل از پرواز
    }
}
