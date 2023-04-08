using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Bus
{
    /// <summary>
    ///نوع خدمت
    ///مثال راننده و...
    /// </summary>
    public class TypeServiceProviderBus : BaseEntitySimple<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }

}
