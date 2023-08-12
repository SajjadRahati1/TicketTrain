namespace EndPoint.Site.Models.Dto
{
    public class PublicListDto : PublicResultDto
    {
        public int OutCount { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
