using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Flight.InternationalFlight
{
    /// <summary>
    /// رزرو و خریداری بلیط ها
    /// خرید یک فرد برای مسافرانش
    /// </summary>
    public class TicketInternationalFlightReservation : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public InternationalFlight Flight { get; set; }


        public string TicketNumber { get; set; }
        /// <summary>
        /// این شماره رو خود سایت میسازد
        /// </summary>
        public string OrderNumber { get; set; }


        /// <summary>
        /// بلیط هایی که این فرد خریداری کرده است
        /// </summary>
        public List<TicketInternationalFlight> Tickets { get; set; }

        /// <summary>
        /// اطلاعات بلیط و اطلاع‌رسانی بعدی به این ادرس ارسال می‌شود.
        /// </summary>
        public string SendOtherInformationToPhoneNumber { get; set; }
        /// <summary>
        /// اطلاعات بلیط و اطلاع‌رسانی بعدی به این ادرس ارسال می‌شود.
        /// </summary>
        public string SendOtherInformationToEmail { get; set; }




        public Transaction Transaction { get; set; }
        public long TransactionId { get; set; }

    }
}
