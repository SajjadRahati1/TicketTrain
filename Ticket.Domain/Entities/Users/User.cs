using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
using Ticket.Domain.Entities.Refrences.Flight.InternationalFlight;

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

        #region بلیط های خریداری شده

        /// <summary>
        /// بلیط های پرواز های داخلی خریداری شده توسط شخص
        /// </summary>
        public ICollection<TicketDomesticFlightReservation> TicketDomesticFlights { get; set; }
        /// <summary>
        /// بلیط های پرواز خارجی خریداری شده توسط شخص
        /// </summary>
        public ICollection<TicketInternationalFlightReservation> TicketInternationalFlights { get; set; }
        #endregion
    }
}
