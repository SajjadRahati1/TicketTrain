using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Domain.Enums
{
    /// <summary>
    /// نوع کوپه های قطار
    /// </summary>
    public enum TrainCompartmentType
    {
        /// <summary>
        /// کوپه ای 6 تخته
        /// </summary>
        [Display(Name = "کوپه ای 6 تخته")]
        Seater6Coupe,


        /// <summary>
        /// کوپه ای 4 تخته
        /// </summary>
        [Display(Name = "کوپه ای 4 تخته")]
        Seater4Coupe

    }
}
