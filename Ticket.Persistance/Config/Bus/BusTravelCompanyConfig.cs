using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Refrences.Bus;

namespace Ticket.Persistance.Config.Bus
{
    public class BusTravelCompanyConfig : IEntityTypeConfiguration<BusTravelCompany>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BusTravelCompany> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(300);
            builder.Property(p=>p.Description).HasMaxLength(4000);
            builder.Property(p => p.SiteUrl).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Address).HasMaxLength(300);
            builder.Property(p => p.Phone).HasMaxLength(300);
        }
    }
}
