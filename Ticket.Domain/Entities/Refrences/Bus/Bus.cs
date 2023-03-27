using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Bus
{
    /// <summary>
    /// اتوبوس مسافرتی
    /// </summary>
    public class Bus : BaseEntitySimple<int>
    {
        /// <summary>
        /// شماره پلاک
        /// </summary>
        public string NumberPlates { get; set; }

        /// <summary>
        /// سال ساخت
        /// </summary>
        public DateOnly CreatedDate { get; set; }

        public BusType BusType { get; set; }

        public List<BusTravel> Travels { get; set; }

        /// <summary>
        /// در صورت داشتن عکس آنها را نمایش میدهیم
        /// </summary>
        public List<Image> Images { get; set; }
    }

}
