namespace EndPoint.Site.Models.Dto.DomesticFlight
{
    public class RequestAddTicketDFReserveDto
    {
        public long FlightId { get; set; }

        /// <summary>
        /// اطلاعات بلیط و اطلاع‌رسانی بعدی به این ادرس ارسال می‌شود.
        /// </summary>
        public string? SendOtherInformationToPhoneNumber { get; set; }
        /// <summary>
        /// اطلاعات بلیط و اطلاع‌رسانی بعدی به این ادرس ارسال می‌شود.
        /// </summary>
        public string? SendOtherInformationToEmail { get; set; }
        /// <summary>
        /// لیست مسافر های شخص
        /// </summary>
        public List<long> Passengers { get; set; }
    }
    public class ResultAddTicketDFReserveDto
    {
        public string? TicketNumber { get; set; }
        /// <summary>
        /// این شماره رو خود سایت میسازد
        /// </summary>
        public string? OrderNumber { get; set; }

        public List<ResultAddTicketDfReservePassengerDto> Passengers { get; set; }
    }
    public class ResultAddTicketDfReservePassengerDto
    {
        public long PassengerId { get; set; }
        public string? TicketNumber { get; set; }
    }
}
