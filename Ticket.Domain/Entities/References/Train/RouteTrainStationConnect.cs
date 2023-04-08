using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    /// اتصال های بین قطار ها که در مسیر قطار هستند
    /// (مسیر قطار)
    /// </summary>
    public class RouteTrainStationConnect : BaseEntity
    {

        public TrainStationConnect TrainStation { get; set; }
        public long TrainStationId { get; set; }
        /// <summary>
        /// ساعت رسیدن به ایستگاه
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// آیا در این مقصد ایست دارد قطار
        /// </summary>
        public bool StopThisDestination { get; set; }

        /// <summary>
        /// قیمت به ازای این مسیر
        /// </summary>
        public long Amount { get; set; }

        public Train Train { get; set; }
        public long TrainId { get; set; }
    }
}

