using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Enums;

namespace Ticket.Domain.Entities.Users
{
    /// <summary>
    /// مشخصات عمومی هر شخص
    /// <para>
    /// از جمله کاربران سرویس دهندگان سفر و..
    /// </para>
    /// </summary>
    public class Person:BaseEntity
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BithDate { get; set; }
        public Gender Gender { get; set; }
    }
}
