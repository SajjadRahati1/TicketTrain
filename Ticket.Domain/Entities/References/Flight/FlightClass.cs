namespace Ticket.Domain.Entities.Refrences.Flight
{
    public class FlightClass
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public FlightClassType ClassType { get; set; }
        public int ClassTypeId { get; set; }
    }
}
