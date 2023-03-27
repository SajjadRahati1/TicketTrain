using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// هواپیما و اطلاعات آن
    /// </summary>
    public class AirPlane : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        /// <summary>
        /// رتبه هواپیما
        /// </summary>
        public short Rank { get; set; }

        /// <summary>
        /// تعداد مسافران
        /// <para>برای مقدار دهی دیفالت و اولیه به پرواز</para>
        /// </summary>
        public int MaxNumberPassenger { get; set; }
        /// <summary>
        /// مقدار بار مجاز
        /// <para>برای مقدار دهی دیفالت و اولیه به پرواز</para>
        /// </summary>
        public int AllowableAmountLoad { get; set; }

        public AirPlaneType AirPlaneType { get; set; }
        /// <summary>
        /// first class or other
        /// </summary>
        public short AirPlaneTypeId { get; set; }

        /// <summary>
        /// در صورت داشتن عکس آنها را نمایش میدهیم
        /// </summary>
        public List<Image> Images { get; set; }

    }


}
//کمپانی رو هم بنویس