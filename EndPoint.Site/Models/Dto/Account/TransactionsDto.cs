namespace EndPoint.Site.Models.Dto.Account
{
    public class TransactionsDto:PublicListDto
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public string? ReferenceType { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public string SearchText { get; set; }
     

        public List<TransactionDto> Transactions { get; set; }
    }
}
