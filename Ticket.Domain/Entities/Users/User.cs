using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Users
{
    public class User : IdentityUser
    {
    
        /// <summary>
        /// اطلاعات شخصی کاربر
        /// <para>
        /// public string Name { get; set; }
        /// </para>
        /// <para>
        /// public string NationalCode { get; set; }
        /// </para>
        /// </summary>
        public long PersonId { get; set; }
        /// <summary>
        /// اطلاعات شخصی کاربر
        /// <para>
        /// public string Name { get; set; }
        /// </para>
        /// <para>
        /// public string NationalCode { get; set; }
        /// </para>
        /// </summary>
        public Person Person { get; set; }
       
        /// <summary>
        /// بلیط های قطار این کاربر
        /// </summary>
        public List<Ticket.Ticket> Tickets { get; set; }

        /// <summary>
        /// کیف پول کاربر
        /// </summary>
        public Wallet Wallet { get; set; }

        /// <summary>
        /// آیا این کاربر بلاک شده است یا خیر
        /// </summary>
        public bool IsBlocked { get; set; }
    }
    public class Passenger : BaseEntity
    {
        /*
        //اطلاعات پایه
  PersonID long [ref: - Per.ID]
  //نام انگلیسی
  En_FirstName nvarchar(200)
  En_LastName nvarchar(200)
  //تاریخ اتمام شماره پاسپورت
  ExpireDatePassport date
  //کشور محل تولد
  CountryBirth long [ref: > Co.ID]
         */
        public long PersonId { get; set; }
        public Person Person { get; set; }

        public string En_FirstName { get; set; }
        public string En_LastName { get; set; }

        public DateTime ExpireDatePassport { get; set; }

        public long CountryBirthId { get; set; }
    }
}
