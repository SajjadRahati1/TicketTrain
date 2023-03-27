using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// اطلاعات تماس ایرلاین
    /// </summary>
    public class AirLineContants : BaseEntitySimple<int>
    {
        public int AirLineId { get; set; }
        public AirLine AirLine { get; set; }

        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Address { get; set; }

    }


}
//کمپانی رو هم بنویس