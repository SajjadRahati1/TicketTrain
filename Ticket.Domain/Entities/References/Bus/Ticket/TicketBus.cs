using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;
using Ticket.Domain.Enums;

namespace Ticket.Domain.Entities.Refrences.Bus.Ticket
{
    /// <summary>
    /// بلیط اتوبوس به ازای هر مسافر
    /// </summary>
    public class TicketBus : BaseEntitySimple
    {
        public TicketBusReservation Reservation { get; set; }
        public string NationalCode { get; set; }
        /// <summary>
        /// شماره صندلی مشخص شده
        /// </summary>
        public int SeatNumber { get; set; }
        public Gender Gender { get; set; }

        /// <summary>
        /// اگر تنها کد ملی را هم وارد کند کافی است ولی میتواند از مسافران قبلی خود نیز استفاده کند
        /// </summary>
        public Passenger? Passenger { get; set; }
        public long? PassengerId { get; set; }

        public TicketBusReturned? Returned { get; set; }
        public long? ReturnedId { get; set; }
    }

}
