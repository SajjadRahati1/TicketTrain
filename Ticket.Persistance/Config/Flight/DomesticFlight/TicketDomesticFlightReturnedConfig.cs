using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
namespace Ticket.Persistance.Config.Flight.DomesticFlight
{
    public class TicketDomesticFlightReturnedConfig : IEntityTypeConfiguration<TicketDomesticFlightReturned>
    {
        public void Configure(EntityTypeBuilder<TicketDomesticFlightReturned> builder)
        {
        }
    }
}
