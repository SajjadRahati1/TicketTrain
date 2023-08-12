namespace Ticket.Domain.Entities.Common
{
    /// <summary>
    /// شهر
    /// </summary>
    public class City : BaseEntitySimple
    {
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public State State { get; set; }
        public long StateId { get; set; }
    }

}
