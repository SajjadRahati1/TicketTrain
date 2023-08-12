using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Refrences.Bus;

namespace Ticket.Persistance.Config.Bus
{
    public class TypeServiceProviderBusConfig : IEntityTypeConfiguration<TypeServiceProviderBus>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TypeServiceProviderBus> builder)
        {
            builder.Property(p=>p.Title).HasMaxLength(1000);
            builder.HasAlternateKey(p => p.Title);            
        }
    }
}
