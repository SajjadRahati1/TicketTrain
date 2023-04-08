using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    ///نوع خدمت
    ///مثال کمک خلبان ،خلبان و...
    /// </summary>
    public class TypeServiceProviderAirPlane : BaseEntitySimple<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }


}
//کمپانی رو هم بنویس