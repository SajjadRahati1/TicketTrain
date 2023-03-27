using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    ///نوع خدمت
    ///مثال راننده و...
    /// </summary>
    public class TypeServiceProviderTrain : BaseEntitySimple<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

