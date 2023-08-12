using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Refrences.Bus;

namespace Ticket.Persistance.Config.Bus
{
    public class BusTerminalConfig : IEntityTypeConfiguration<BusTerminal>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BusTerminal> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(150);
            builder.Property(p => p.Description).HasMaxLength(2000);
            builder.Property(p => p.CityId).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
