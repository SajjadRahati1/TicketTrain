using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Bus
{
    /// <summary>
    /// ترمینال اتوبوس
    /// </summary>
    public class BusTerminal:BaseEntitySimple
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public long CityId { get; set; }
        public City City { get; set; }

        //فاصله دو شهر را میتوان به صورت 
        //Api
        // از گوکل یا بلد و ...به دست آورد
    }
}
