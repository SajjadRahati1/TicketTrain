using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Bus.Ticket
{
    /// <summary>
    /// رزرو و خرید بلیط های مسافران توسط یک فرد <see cref="Users.User"/>
    /// </summary>
    public class TicketBusReservation : BaseEntitySimple
    {
        public User User { get; set; }
        public long UserId { get; set; }

        public BusTravel BusTravel { get; set; }
        public long BusTravelId { get; set; }

        /// <summary>
        /// سرپرست سفر برای این خرید تیکت
        /// </summary>
        public Passenger Supervisor { get; set; }
        public long SupervisorId { get; set; }

        public List<TicketBus> Tickets { get; set; }


        public string TicketNumber { get; set; }
        /// <summary>
        /// این شماره رو خود سایت میسازد
        /// </summary>
        public string OrderNumber { get; set; }


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
