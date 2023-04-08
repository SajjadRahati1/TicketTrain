using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// یک سری قوانین استرداد مشخص داریم که هر بار از همان ها برای پرواز ها استفاده میکنیم
    /// پس برای جلو گیری از تکرار به صورت گروه بندی ایجاد میکنیم تا تنها آیدی گروه نیاز باشد برا پرواز مشخص شود
    /// </summary>
    public class GroupFlightTicketRefundRules:BaseEntity
    {
        public string Title { get; set; }
        public ICollection<FlightTicketRefundRules> TicketRefundRules { get; set; }
    }
}
