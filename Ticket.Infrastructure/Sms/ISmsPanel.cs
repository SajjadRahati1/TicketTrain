using Ticket.Common.Dto;

namespace Ticket.Infrastructure.Sms
{
    public interface ISmsPanel
    {
        public ResultDto SendToOnePerson(SendSmsRequest request);
    }
}
