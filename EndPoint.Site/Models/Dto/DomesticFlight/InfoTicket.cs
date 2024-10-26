namespace EndPoint.Site.Models.Dto.DomesticFlight
{
    public class InfoTicket
    {
        public long DomesticFlightId { get; set; }
        public long FlightId { get; set; }
        /// <summary>
        /// شماره پرواز
        /// </summary>
        public string FlightNumber { get; set; }
        /// <summary>
        /// هواپیمای هوایی
        /// جزو سه badge بالا
        /// </summary>
        public string AirCraft { get; set; }
        /// <summary>
        /// شماره ترمینال
        /// مثال : ترمینال : شماره 2
        /// </summary>
        public int TerminalNumber { get; set; }
        public string AirlineCode { get; set; }
        public long AirLineId { get; set; }
        public string AirlineLogo { get; set; }
        public string AirlineName { get; set; }
        //public List<string> AppliedRules { get; set; }
        public DateTime EndMovingDateTime { get; set; }
        public long DiscountId { get; set; }
        public string DiscountText { get; set; }
        public string Class { get; set; }
        public long ClassTypeID { get; set; }
        /// <summary>
        /// پرواز : اکونومی
        /// </summary>
        public string ClassTypeName { get; set; }
        public int Commission { get; set; }
        public string GroupRefundRulesTitle { get; set; }
        public string Description { get; set; }
        public long Destination { get; set; }
        public string DestinationName { get; set; }

        public bool IsCharter { get; set; }
        public bool IsRefundable { get; set; }
        public bool IsSelectableInRoundtrip { get; set; }
        public DateTime StartMovingDateTime { get; set; }
        public int MaxAllowdBaggage { get; set; }
        public long OriginId { get; set; }
        public string OriginName { get; set; }
        public decimal PriceAdult { get; set; }
        public decimal PriceChild { get; set; }
        public decimal PriceTeenage { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int Seat { get; set; }
        public short Stars { get; set; }
    }
    
}
