using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// تگ هایی مانند سیستمی / چارتر و...
    /// </summary>
    public class FlightTag:BaseEntitySimple
    {
        public string Title { get; set; }
    }
}
