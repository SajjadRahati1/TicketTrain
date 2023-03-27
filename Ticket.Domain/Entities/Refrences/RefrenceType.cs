using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences
{
    /// <summary>
    ///نوع را مشخص میکند برای مثال 
    ///پرداخت برای بلیط هواپیما است
    ///پس باید در رفرنس آیدی، آیدی بلیط های دریافتی باشد
    ///<code>
    ///values is :
    ///1.DomesticFlight #پرواز داخلی
    ///2.InternationalFlights #پرواز خارجی
    ///3.TravelBus #سفر با اتوبوس
    ///4.TravelTrain #سفر با قطار
    ///5.ReserveHotel #رزرو هتل --> فعلا این قسمت منسوخ است
    ///6.BackMoney #برداشت پول از کیف پول (بازگشت پول(
    ///7.AddMoney #افزودن پول به کیف پول
    /// </code>
    /// </summary>
    public class RefrenceType:BaseEntitySimple<int>
    {
        public string Title { get; set; }
        public string EntityName { get; set; }
    }
}
