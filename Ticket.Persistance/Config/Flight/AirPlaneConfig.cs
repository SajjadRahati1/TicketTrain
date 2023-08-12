using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class AirPlaneConfig : IEntityTypeConfiguration<AirPlane>
    {
        public void Configure(EntityTypeBuilder<AirPlane> builder)
        {
            builder.Property(p => p.Code).HasMaxLength(100);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Rank).IsRequired();
        }
    }
}
