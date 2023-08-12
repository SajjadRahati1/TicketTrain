using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Flightt = Ticket.Domain.Entities.Refrences.Flight.Flight;
namespace Ticket.Persistance.Config.Flight
{
    public class FlightConfig : IEntityTypeConfiguration<Flightt>
    {
        public void Configure(EntityTypeBuilder<Flightt> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.FlightNumber).HasMaxLength(15);
            builder.Property(p => p.MaxNumberPassenger).HasMaxLength(1000);
            builder.Property(p => p.SmallTitle).HasMaxLength(50);
            
        }
    }
}
