using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class AirLineContantsConfig : IEntityTypeConfiguration<AirLineContants>
    {
        public void Configure(EntityTypeBuilder<AirLineContants> builder)
        {
            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(p => p.Email)
                .HasMaxLength(300);
            builder.Property(p => p.Fax)
                .HasMaxLength(500);
            builder.Property(p => p.WebSite)
                .HasMaxLength(300);
            builder.Property(p => p.Address)
                .HasMaxLength(1000);

        }
    }
}
