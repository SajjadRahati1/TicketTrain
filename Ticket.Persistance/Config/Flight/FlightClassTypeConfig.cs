using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class FlightClassTypeConfig : IEntityTypeConfiguration<FlightClassType>
    {
        public void Configure(EntityTypeBuilder<FlightClassType> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(300);
        }
    }
    
}
