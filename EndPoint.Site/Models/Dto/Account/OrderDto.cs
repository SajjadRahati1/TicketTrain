namespace EndPoint.Site.Models.Dto.Account
{
    public class OrderDto
    {
        public long Id { get; set; }

        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }


        public string? FlightNumber { get; set; }
        public string? FromCity { get; set; }
        public string? ToCity { get; set; }
        public string? MovingDate { get; set; }


        public string? OrderNumber { get; set; }
        public string? TicketNumber { get; set; }
        public int TicketsCount { get; set; }
        public bool IsRemoved { get; set; }
        public string? RemoveDateTime { get; set; }
    }
}
