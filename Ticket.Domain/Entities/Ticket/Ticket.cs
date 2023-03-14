using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Train;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Ticket
{
    /// <summary>
    /// بلیط قطار
    /// </summary>
    public class Ticket : BaseEntity
    {
        /// <summary>
        /// به نام چه فردی
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// کد ملی فرد
        /// </summary>
        public string NationalCode { get; set; }
        /// <summary>
        /// سن فرد
        /// </summary>
        public int Age { get; set; }
        public User User { get; set; }
        public SeatOrBed SeatOrBed { get; set; }

        public TrainRoute.TrainRoute TrainRoute { get; set; }

        /// <summary>
        /// شهر مبدا
        /// </summary>
        public City CityOrigin { get; set; }
        /// <summary>
        /// شهر مقصد
        /// </summary>
        public City CityDestination { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// کد ساخته شده
        /// </summary>
        public string TrackingCode { get; set; }
    }
}
