using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences.Bus.Ticket;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Domain.Entities.Refrences.Bus
{
    public class BusTravel:BaseEntity
    {
        /// <summary>
        /// ترمینال مبدا
        /// </summary>
        public long OriginTerminalId { get; set; }
        public BusTerminal OriginTerminal { get; set; }
        /// <summary>
        /// ترمینال مقصد
        /// </summary>
        public long DestinationTerminalId { get; set; }
        public BusTerminal DestinationTerminal { get; set; }

        /// <summary>
        /// تاریخ حرکت
        /// </summary>
        public DateTime StartMoving { get; set; }

     
        /// <summary>
        /// مقدار بار مجاز
        /// دیفالت از <see cref="BusType"/> دریافت شود
        /// </summary>
        public int AllowableAmountLoad { get; set; }
        public Bus Bus { get; set; }
        public List<ServiceProviderBus> ServiceProviders { get; set; }
        public List<TicketBusReservation> ticketBusReservations { get; set; }


        /// <summary>
        /// شرکت مسافربری
        /// مثال : کاوه نگار
        /// </summary>
        public BusTravelCompany Company { get; set; }
        public long CompanyId { get; set; }


    }
}
