using System.ComponentModel.DataAnnotations;

namespace Ticket.Domain.Enums
{
    /// <summary>
    ///نوع را مشخص میکند برای مثال 
    ///پرداخت برای بلیط هواپیما است
    ///پس باید در رفرنس آیدی، آیدی بلیط های دریافتی باشد
    /// </summary>
    public enum ReferenceType
    {
        [Display(Name = "پرواز داخلی")]
        DomesticFlight =1,
        [Display(Name = "پرواز خارجی")]
        InternationalFlights =2,
        [Display(Name = "سفر با اتوبوس")]
        TravelBus = 3,
        [Display(Name = "سفر با قطار")]
        TravelTrain = 4,
        [Display(Name = "رزرو هتل")]
        ReserveHotel = 5,
        [Display(Name = "برداشت پول از کیف پول")]
        BackMoney = 6,
        [Display(Name = "افزودن پول به کیف پول")]
        AddMoney = 7,

    }
}
