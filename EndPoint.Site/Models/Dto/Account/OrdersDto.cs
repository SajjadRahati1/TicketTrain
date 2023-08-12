namespace EndPoint.Site.Models.Dto.Account
{
    public class OrdersDto:PublicListDto
    {
        public long? DomesticFlightId { get; set; }
      
        public long? TicketReservationId { get; set; }
        public bool? IsRemoved { get; set; }
        public bool? IsReturned { get; set; }
        public string? SearchText { get; set; }
        public long? PassengerId { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
