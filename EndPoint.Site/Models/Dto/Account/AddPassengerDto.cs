namespace EndPoint.Site.Models.Dto.Account
{
    public class AddPassengerDto:PublicResultDto
    {
        public string En_FirstName { get; set; }
        public string En_LastName { get; set; }
        /// <summary>
        /// تاریخ اتمام شماره پاسپورت
        /// </summary>
        public DateTime ExpireDatePassport { get; set; }
        /// <summary>
        /// کشور محل تولد
        /// </summary>
        public long CountryBirthId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NationalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string BirthDte { get; set; }
        public bool Gender { get; set; }
    }
    public class EditPassenger: AddPassengerDto
    {
        public long Id { get; set; }
    }
}
