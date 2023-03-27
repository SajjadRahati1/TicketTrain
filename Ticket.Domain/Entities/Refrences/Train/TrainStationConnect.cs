using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Train
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
        public TrainStation TrainStationOriginId { get; set; }
        /// <summary>
        /// ایستگاه مبدا
        /// </summary>
        public TrainStation TrainStationDestination { get; set; }
        public long TrainStationDestinationId { get; set; }


    }
}

