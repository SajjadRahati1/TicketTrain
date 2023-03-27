using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    public class AirLine : BaseEntitySimple<int>
    {

        public string LogoUrl { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// کد مرجع ایرلاین
        /// </summary>
        public string Code { get; set; }

        public AirLineFinancial AirLineFinancial { get; set; }

        public AirLineContants AirLineContants { get; set; }


    }


}
//کمپانی رو هم بنویس