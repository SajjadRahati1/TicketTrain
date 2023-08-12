using System.Diagnostics;
using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    /// حرکت قطار/مسافرت ها با قطار
    /// </summary>
    public class TrainTravel : BaseEntity
    {
        /// <summary>
        /// قطار
        /// </summary>
        public Train Train { get; set; }
        public long TrainId { get; set; }
        //باید سرویس دهندگان سفر را داشته باشیم
        /*  public Driver Driver { get; set; }
          public long DriverId { get; set; }*/


        /// <summary>
        /// سرویس دهندگان سفر
        /// </summary>
        public List<ServiceProviderTrain> ServiceProviders { get; set; }
        public ICollection<RouteTrainStationConnect> TrainStations { get; set; }

        /// <summary>
        /// برای قیمت به ازای هر فرد(صندلی) که خالی بماند برای کوپه دربست
        /// </summary>
        public decimal PricePerPersonForClosedCompartment { get; set; }
        //به عنوان مثال اگر کوپه 4 نفری را 2 نفر به صورت دربست دریافت کنند باید مقدار مشخص شده در بالا را
        //به ازای دو صندلی خالی دیگر پرداخت کنند

        /// <summary>
        /// قیمت هر صندلی یا تخت به ازای هر فرد
        /// </summary>
        public decimal PricePerPerson { get; set; }

        /// <summary>
        /// قوانین استرداد
        /// </summary>
        public GroupTrainTicketRefundRules RefundRules { get; set; }


        /// <summary>
        /// امکانات کوپه
        /// </summary>
        public string CoupeFacilities { get; set; }
        /// <summary>
        /// امکانات عمومی قطار
        /// </summary>
        public string GeneralTrainFacilities { get; set; }

        /*
                /// <summary>
                /// لیست کوپه های قطار
                /// </summary>
                public List<Compartment> Compartments { get; set; }*/

        public string SmallTitle { get; set; }
    }
}

