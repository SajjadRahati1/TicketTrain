namespace EndPoint.Site.Models.Dto.DomesticFlight
{
    public class SelectTicketDFDto
    {
        //[Required(ErrorMessage ="لطفا شهر مبدا را مشخص کنید")]
        public long FromCity { get; set; }
        //[Required(ErrorMessage ="لطفا شهر مقصد را مشخص کنید")]
        public long ToCity { get; set; }
        //[Required]
        public string FromDate { get; set; }

        public int SeniorPassengerCount { get; set; }
        public int TeenagerPassnegerCount { get; set; }
        public int BabyPassengerCount { get; set; }


    }
    public class ResultSelectTickets
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
        public string EndMovingDateTimePersian { get; set; }
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
        public List<ResultTicketDFRefundRulesDto> ResultTicketRefundRules { get; set; }
        public string Description { get; set; }
        public long Destination { get; set; }
        public string DestinationName { get; set; }

        public bool IsCharter { get; set; }
        public bool IsRefundable { get; set; }
        public bool IsSelectableInRoundtrip { get; set; }
        public DateTime StartMovingDateTime { get; set; }
        public string StartMovingDateTimePersian { get; set; }
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
    public class ResultTicketDFRefundRulesDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        /// <summary>
        /// مبلغ قابل کسر
        /// </summary>
        public decimal DeductibleAmount { get; set; }

        /// <summary>
        /// مبلغ به صورت درصدی در نظر گرفته شود
        /// </summary>
        public bool IsPercent { get; set; }

        /// <summary>
        /// شروع از چه مدت پس از صدور بلیط
        /// </summary>
        public TimeSpan? Start_AfterIssuanceTicket { get; set; }
        /// <summary>
        /// پایان از چه مدت پس از صدور بلیط
        /// </summary>
        public TimeSpan? End_AfterIssuanceTicket { get; set; }
        //مثال : از زمان صدور بلیط تا 4 روز پس از آن مهلت انقضا به این قانون استرداد وجود دارد

        /// <summary>
        /// شروع از چه مدت قبل از پرواز
        /// </summary>
        public TimeSpan? Start_BeforeFlight { get; set; }
        /// <summary>
        /// پایان از چه مدت قبل از پرواز
        /// </summary>
        public TimeSpan? End_BeforeFlight { get; set; }
        //مثال : از 2 روز قبل از پرواز تا 1 روز قبل از پرواز مهلت انقضا به این قانون استرداد وجود دارد

        /// <summary>
        /// در روز استرداد بلیط شروع از چه ساعتی باشد
        /// </summary>
        public short? StartHour { get; set; }
        /// <summary>
        /// در روز استرداد بلیط شروع از چه ساعتی باشد
        /// </summary>
        public short? EndHour { get; set; }
    }
    
}
