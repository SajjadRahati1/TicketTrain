namespace EndPoint.Site.Models.Dto
{
    public class ResultShowDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string TypeMessage { get; set; }
        
    }
    public class ResultShowDto<T>: ResultShowDto
    {
        public T Data { get; set; }
    }
}
