using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.TrainRoute
{
    /// <summary>
    /// اتصال بین ایستگاه های قطار 
    /// </summary>
    public class TrainStationConnect
    {
        /// <summary>
        /// ایستگاه مقصد
        /// </summary>
        public City TrainStationOrigin { get; set; }
        public long TrainStationOriginId { get; set; }
        /// <summary>
        /// ایستگاه مبدا
        /// </summary>
        public City TrainStationDestination { get; set; }
        public long TrainStationDestinationId { get; set; }


    }



}
