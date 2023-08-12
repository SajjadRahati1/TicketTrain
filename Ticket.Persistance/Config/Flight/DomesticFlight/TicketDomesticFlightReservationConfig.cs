using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
namespace Ticket.Persistance.Config.Flight.DomesticFlight
{
    public class TicketDomesticFlightReservationConfig : IEntityTypeConfiguration<TicketDomesticFlightReservation>
    {
        public void Configure(EntityTypeBuilder<TicketDomesticFlightReservation> builder)
        {
            builder.HasIndex(p => p.TicketNumber).IsUnique();
            builder.HasIndex(p => p.OrderNumber).IsUnique();

        }
    }
}
