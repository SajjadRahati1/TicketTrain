namespace Ticket.Domain.Entities.Common
{
    public class Bank : BaseEntitySimple
    {
        public string? Name { get; set; }
        public string? UrlImage { get; set; }
        public string? Description { get; set; }
        public string? CountryId { get; set; }
        public Country Country { get; set; }
    }

}
