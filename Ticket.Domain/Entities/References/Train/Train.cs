using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Enums;
using Ticket.Domain.Entities.Refrences.Bus;

namespace Ticket.Domain.Entities.Refrences.Train
{

    public class Train : BaseEntity
    {
        /// <summary>
        /// نام قطار
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// شماره قطار
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// نوع کوپه های قطار
        /// </summary>
        public TrainCompartmentType CompartmentType { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// ظرفیت قطار
        /// </summary>
        public int Capacity { get; set; }


        /// <summary>
        /// تعداد کوپه ها
        /// </summary>
        public int CompartmentCount { get; set; }
        /// <summary>
        /// کوپه هایش به صورت تختی هستند
        /// </summary>
        public bool HaveBed { get; set; }

        public List<TrainTravel> TrainRoutes { get; set; }


        #region مقادیر دیفالت
        /// <summary>
        /// مقدار دیفالت برای قیمت به ازای هر فرد(صندلی) که خالی بماند برای کوپه دربست
        /// </summary>
        public decimal Default_PricePerPersonForClosedCompartment { get; set; }
        //به عنوان مثال اگر کوپه 4 نفری را 2 نفر به صورت دربست دریافت کنند باید مقدار مشخص شده در بالا را
        //به ازای دو صندلی خالی دیگر پرداخت کنند

        /// <summary>
        /// قیمت هر صندلی یا تخت به ازای هر فرد
        /// </summary>
        public decimal Default_PricePerPerson { get; set; }

        /// <summary>
        /// امکانات کوپه
        /// </summary>
        public string CoupeFacilities{ get; set; }
        /// <summary>
        /// امکانات عمومی قطار
        /// </summary>
        public string GeneralTrainFacilities { get; set; }
        #endregion

        /// <summary>
        /// در صورت داشتن عکس آنها را نمایش میدهیم
        /// </summary>
        public List<Image> Images { get; set; }
    }
}

