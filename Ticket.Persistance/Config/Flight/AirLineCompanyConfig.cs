using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class AirLineCompanyConfig : IEntityTypeConfiguration<AirLineCompany>
    {
        public void Configure(EntityTypeBuilder<AirLineCompany> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);
            builder.HasIndex(p => p.Name);

            builder.Property(p => p.ImageUrl).HasMaxLength(400);
            builder.Property(p => p.SiteUrl).HasMaxLength(400);
            builder.Property(p => p.Description).HasMaxLength(4000);

        }
    }
}
