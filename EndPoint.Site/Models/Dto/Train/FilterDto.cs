using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.Dto.Train
{
    public class FilterTrainDto
    {
        //[Required(ErrorMessage ="لطفا شهر مبدا را مشخص کنید")]
        public long FromCity { get; set; }
        //[Required(ErrorMessage ="لطفا شهر مقصد را مشخص کنید")]
        public long ToCity { get; set; }
        //[Required]
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int SeniorPassengerCount { get; set; }
        public int TeenagerPassnegerCount { get; set; }
        public int BabyPassengerCount { get; set; }
    }
}
