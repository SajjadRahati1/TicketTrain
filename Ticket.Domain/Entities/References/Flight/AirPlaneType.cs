using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// نوع هواپیما
    /// <code>
    /// 1.First class
    /// 2. ...
    /// </code>
    /// </summary>
    public class AirPlaneType : BaseEntitySimple<short>
    {
        public string Title { get; set; }
    }


}
//کمپانی رو هم بنویس