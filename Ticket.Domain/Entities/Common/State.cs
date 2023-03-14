namespace Ticket.Domain.Entities.Common
{
    /// <summary>
    /// استان
    /// </summary>
    public class State : BaseEntitySimple
    {
        public string Name { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
    }

}
