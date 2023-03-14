using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Refrences.Flight
{
    /// <summary>
    /// اطلاعات عمومی پرواز
    /// </summary>
    public class Flight : BaseEntity
    {
        /// <summary>
        /// ترمینال مبدا
        /// </summary>
        public long OriginTerminalId { get; set; }
        public AirplaneTerminal OriginTerminal { get; set; }
        /// <summary>
        /// ترمینال مقصد
        /// </summary>
        public long DestinationTerminalId { get; set; }
        public AirplaneTerminal DestinationTerminal { get; set; }
        /// <summary>
        /// شماره پرواز
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// تعداد مسافران
        /// </summary>
        public int MaxNumberPassenger { get; set; }
        /// <summary>
        /// مقدار بار مجاز
        /// </summary>
        public int AllowableAmountLoad { get; set; }


        /// <summary>
        /// هواپیما
        /// </summary>
        public long AirPlaneId { get; set; }
        /// <summary>
        /// شرکت مسافربری
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// شرکت هواپیمایی
        /// </summary>
        public long AirLineId { get; set; }

        /// <summary>
        /// تاریخ حرکت
        /// </summary>
        public DateTime StartMoving { get; set; }

        /// <summary>
        /// ایا به صورت چارتری هست یا خیر
        /// </summary>
        public bool IsCharter { get; set; }
    }

    /// <summary>
    /// ترمینال هواپیما
    /// </summary>
    public class AirplaneTerminal:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public long CityId { get; set; }
        public City City { get; set; }
    }

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


    }
    /// <summary>
    /// نوع هواپیما
    /// <code>
    /// 1.First class
    /// 2. ...
    /// </code>
    /// </summary>
    public class AirPlaneType : BaseEntitySimple<short>
    {
        public string Title { get; set; }
    }

    public class AirLine:BaseEntitySimple<int>
    {
       
        public string LogoUrl { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public AirLineFinancial AirLineFinancial { get; set; }
       
        public AirLineContants AirLineContants { get; set; }
       

    }
    /// <summary>
    /// اطلاعات مالی ایرلاین
    /// </summary>
    public class AirLineFinancial : BaseEntitySimple<int>
    {
        public int AirLineId { get; set; }
        public AirLine AirLine { get; set; }

       
        /// <summary>
        /// کد اقتصادی
        /// </summary>
        public string EnConomicCode { get; set; }
        /// <summary>
        ///شناسه ملی
        /// </summary>
        public string NationalId { get; set; }
        /// <summary>
        ///شماره حساب
        /// </summary>
        public string AccountNumber { get; set; }
        public long BankId { get; set; }
        public Bank Bank { get; set; }
        /// <summary>
        ///شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }

        public string SalesReportLink { get; set; }

    }
    /// <summary>
    /// اطلاعات تماس ایرلاین
    /// </summary>
    public class AirLineContants : BaseEntitySimple<int>
    {
        public int AirLineId { get; set; }
        public AirLine AirLine { get; set; }

        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Address { get; set; }

    }

  
    public class ServiceProviderAirPlane:BaseEntity
    {
        /// <summary>
        /// اطلاعات عمومی سرویس دهنده
        /// </summary>
        public Person Person { get; set; }
        public long PersonId { get; set; }

        /// <summary>
        /// میتونه خالی هم باشه اگر اطلاعات کامل باشه
        /// <para>نکته : اگر هم اینجا یک پرسن داشت و هم در یوزر باید حتما چک شود که 
        /// هردو پرسن یک آیدی باشد و به دو پرسن منتهی نشود</para>
        /// </summary>
        public User User { get; set; }
        public long? UserId { get; set; }
        /// <summary>
        ///نوع خدمت
        ///مثال کمک خلبان ،خلبان و...
        /// </summary>
        public long TypeServiceId { get; set; }
        /// <summary>
        ///نوع خدمت
        ///مثال کمک خلبان ،خلبان و...
        /// </summary>
        public TypeServiceProviderAirPlane TypeService { get; set; }

        public long CompanyID { get; set; }
    }
    /// <summary>
    ///نوع خدمت
    ///مثال کمک خلبان ،خلبان و...
    /// </summary>
    public class TypeServiceProviderAirPlane : BaseEntitySimple<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
//کمپانی رو هم بنویس