using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Refrences.Train.Ticket;

namespace Ticket.Domain.Entities.Refrences.Train
{
    /// <summary>
    /// کوپه قطار
    /// </summary>
    public class Compartment : BaseEntity
    {
        public int Number { get; set; }
        public TicketTrainReservation TicketTrain { get; set; }

        public string Title { get; set; }


    }
}

