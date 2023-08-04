namespace Ticket.Domain.Entities.Common
{
    public class Pricing
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal TeenagePrice { get; set; }
        public decimal ChildPrice { get; set; }

    }
}
