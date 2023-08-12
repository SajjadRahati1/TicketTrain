using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class AirPlaneTypeConfig : IEntityTypeConfiguration<AirPlaneType>
    {
        public void Configure(EntityTypeBuilder<AirPlaneType> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
            builder.HasIndex(p => p.Title).IsUnique();
        }
    }
}
