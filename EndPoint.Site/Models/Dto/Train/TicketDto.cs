namespace EndPoint.Site.Models.Dto.Train
{
    public class TicketDto
    {
        public long Id { get; set; }
        public int ChairCount { get; set; }
        public decimal Price { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string TrainName { get; set; }
        
    }
}
