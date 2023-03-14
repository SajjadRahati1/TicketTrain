using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Enums;
using Ticket.Domain.Entities.Ticket;
namespace Ticket.Domain.Entities.Train
{

    public class Train : BaseEntity
    {
        /// <summary>
        /// نام قطار
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// شماره قطار
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// نوع کوپه های قطار
        /// </summary>
        public TrainCompartmentType CompartmentType { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// ظرفیت قطار
        /// </summary>
        public int Capacity { get; set; }

    
        /// <summary>
        /// لیست کوپه ها
        /// </summary>
        public List<Compartment> Compartments { get; set; }
        /// <summary>
        /// کوپه هایش به صورت تختی هستند
        /// </summary>
        public bool HaveBed { get; set; }

        public List<TrainRoute.TrainRoute> TrainRoutes { get; set; }
    }
    
  

    
}

