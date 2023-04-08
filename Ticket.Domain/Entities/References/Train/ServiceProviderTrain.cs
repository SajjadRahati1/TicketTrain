﻿using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.References;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    /// سرویس دهندگان سفر
    /// </summary>
    public class ServiceProviderTrain : BaseEntitySimple
    {
        /// <summary>
        /// اطلاعات عمومی سرویس دهنده
        /// </summary>
        public Person Person { get; set; }
        public long PersonId { get; set; }

        /// <summary>
        /// میتونه خالی هم باشه اگر اطلاعات کامل باشه
        /// <para>نکته : اگر هم اینجا یک پرسن داشت و هم در یوزر باید حتما چک شود که 
        /// هردو پرسن یک آیدی باشد و به دو پرسن منتهی نشود</para>
        /// </summary>
        public User? User { get; set; }
        public long? UserId { get; set; }
        /// <summary>
        ///نوع خدمت
        ///مثال راننده قطار و...
        /// </summary>
        public long TypeServiceId { get; set; }
        /// <summary>
        ///نوع خدمت
        ///مثال راننده قطار و...
        /// </summary>
        public TypeServiceProviderTrain TypeService { get; set; }

        public List<TrainTravel> BusTravels { get; set; }

        public CompanyServiceProviders Company { get; set; }
        public long CompanyID { get; set; }
    }
}
