using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Train.Ticket
{
    /// <summary>
    /// رزرو و خرید بلیط های مسافران توسط یک فرد <see cref="Users.User"/>
    /// </summary>
    public class TicketTrainReservation : BaseEntity
    {
        public User User { get; set; }
        public long UserId { get; set; }

        public TrainTravel TrainTravel { get; set; }
        public long TrainTravelId { get; set; }


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


        public ICollection<TicketTrain> TicketTrains { get; set; }

        /// <summary>
        /// ایسنگاه مبدا
        /// </summary>
        public TrainStation TrainStationOrigin { get; set; }
        /// <summary>
        /// ایستگاه مقصد
        /// </summary>
        public TrainStation TrainStationDestination { get; set; }
        //باید به اینکه از چه مسیری تا چه مسیری 


        /// <summary>
        /// کوپه دربست 
        /// گرفته شده است یا خیر
        /// </summary>
        public bool IsClosedCompartment { get; set; }

        /// <summary>
        /// لیستی از کوپه هایی که مسافران این فرد داخلش هستند
        /// </summary>
        public List<Compartment> Compartment { get; set; }
        public Transaction Transaction { get; set; }
    }
}

