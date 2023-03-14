using Ticket.Domain.Entities.Common;

namespace Ticket.Domain.Entities.Train
{
    /// <summary>
    /// کوپه قطار
    /// </summary>
    public class Compartment : BaseEntity
    {
        public int Number { get; set; }
        public Train Train { get; set; }
        public long TrainId { get; set; }


    }
}


