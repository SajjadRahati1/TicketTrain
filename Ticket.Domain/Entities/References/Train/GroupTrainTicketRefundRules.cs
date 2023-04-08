using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    /// یک سری قوانین استرداد مشخص داریم که هر بار از همان ها برای قطار ها استفاده میکنیم
    /// پس برای جلو گیری از تکرار به صورت گروه بندی ایجاد میکنیم تا تنها آیدی گروه نیاز باشد برا پرواز مشخص شود
    /// </summary>
    public class GroupTrainTicketRefundRules : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<TrainTicketRefundRules> TicketRefundRules { get; set; }
    }
}

