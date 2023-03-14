using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Train;

namespace Ticket.Domain.Entities.TrainRoute
{
    /// <summary>
    /// حرکت قطار
    /// </summary>
    public class TrainRoute : BaseEntity
    {
        /// <summary>
        /// قطار
        /// </summary>
        public Train.Train Tran { get; set; }
        public long TrainId { get; set; }
        public Driver Driver { get; set; }
        public Guid DriverId { get; set; }
        public ICollection<RouteTrainStationConnect> TrainStations { get; set; }


    }



}
