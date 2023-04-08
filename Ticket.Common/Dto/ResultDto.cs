using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Common.Dto
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }

    public class ResultDto<T> :ResultDto
    {
        
        public T Data { get; set; }
    }

    public enum MessageType
    {
        Success,
        Warning,
        Error,
        Info
    }
}
