using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class FlightClassConfig : IEntityTypeConfiguration<FlightClass>
    {
        public void Configure(EntityTypeBuilder<FlightClass> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(500);
        }
    }
    
}
