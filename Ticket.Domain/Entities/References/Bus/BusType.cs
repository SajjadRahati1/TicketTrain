using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Bus
{
    /// <summary>
    /// نوع چینش صندلی ها و نوع اتوبوس را مشخص میکند
    /// </summary>
    public class BusType:BaseEntitySimple
    {
        public string Name { get; set; }
        /// <summary>
        /// چینش صندلی ها به چه شکل است
        /// مثال :
        /// <para>
        /// *_**/
        /// *_**/
        /// *_**/
        /// *_**/
        /// */
        /// */
        /// *_**/
        /// *_**/
        /// *_**/
        /// *_**/
        /// </para>
        /// </summary>
        public string SeatArrangement { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// تعداد ماکزیمم مسافر
        /// </summary>
        public int MaxNumberPassenger { get; set; }

        /// <summary>
        /// مقدار بار مجاز
        /// </summary>
        public int AllowableAmountLoad { get; set; }



        /// <para>*_**</para>
        /// <para>*_**</para>
        /// <para>*_**</para>
        /// <para>*_**</para>
        /// <para>*</para>
        /// <para>*</para>
        /// <para>*_**</para>
        /// <para>*_**</para>
        /// <para>*_**</para>
        /// <para>*_**</para>
    }


}
