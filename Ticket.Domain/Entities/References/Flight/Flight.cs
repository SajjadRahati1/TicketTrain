using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Financial.Discount;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// اطلاعات عمومی پرواز
    /// </summary>
    public class Flight : BaseEntity
    {
        /// <summary>
        /// ترمینال مبدا
        /// </summary>
        public long OriginTerminalId { get; set; }
        public AirplaneTerminal OriginTerminal { get; set; }
        /// <summary>
        /// ترمینال مقصد
        /// </summary>
        public long DestinationTerminalId { get; set; }
        public AirplaneTerminal DestinationTerminal { get; set; }
        /// <summary>
        /// شماره پرواز
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// تعداد مسافران
        /// </summary>
        public int MaxNumberPassenger { get; set; }
        /// <summary>
        /// مقدار بار مجاز
        /// </summary>
        public int AllowableAmountLoad { get; set; }


        /// <summary>
        /// هواپیما
        /// </summary>
        public long AirPlaneId { get; set; }
        public AirPlane AirPlane { get; set; }
        /// <summary>
        /// شرکت مسافربری
        /// </summary>
        public long CompanyId { get; set; }
        public FlightCompany Company { get; set; }
        /// <summary>
        /// شرکت هواپیمایی
        /// </summary>
        public long AirLineId { get; set; }
        public AirLine AirLine { get; set; }

        /// <summary>
        /// تاریخ حرکت
        /// </summary>
        public DateTime StartMoving { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndMoving { get; set; }

        /// <summary>
        /// ایا به صورت چارتری هست یا خیر
        /// </summary>
        public bool IsCharter { get; set; }

        /// <summary>
        /// نگ های این پرواز
        /// </summary>
        public ICollection<FlightTag> Tags { get; set; }
        /// <summary>
        /// قانون های استرداد بلیط این پرواز
        /// </summary>
        public GroupFlightTicketRefundRules TicketRefundRules { get; set; }

        /// <summary>
        /// سرویس دهندگان سفر 
        /// </summary>
        public List<ServiceProviderAirPlane> ServiceProviders { get; set; }


        public Discount? Discount { get; set; }
        public long? DiscountId { get; set; }

        public FlightClass Class { get; set; }
        public long ClassId { get; set; }

        public string? Description { get; set; }

        public Pricing Pricing { get; set; }
        public long PricingId { get; set; }
    }
}
