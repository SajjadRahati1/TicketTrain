using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Refrences.Bus;

namespace Ticket.Persistance.Config.Bus
{
    public class BusTravelConfig : IEntityTypeConfiguration<BusTravel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BusTravel> builder)
        {
            builder.HasIndex(p => new { p.OriginTerminalId, p.DestinationTerminalId });
        }
    }
}
