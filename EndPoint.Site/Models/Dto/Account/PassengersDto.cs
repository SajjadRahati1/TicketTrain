namespace EndPoint.Site.Models.Dto.Account
{
    public class PassengersDto: PublicListDto
    {
      
        public string? SearchText { get; set; }
      
        public List<PassengerDto> Passengers { get; set; }
    }
}
