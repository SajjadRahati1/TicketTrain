using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class AirplaneTerminalConfig : IEntityTypeConfiguration<AirplaneTerminal>
    {
        public void Configure(EntityTypeBuilder<AirplaneTerminal> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(500);
            
        }
    }
}
