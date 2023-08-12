using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Refrences.Bus;

namespace Ticket.Persistance.Config.Bus
{
    public class ServiceProviderBusConfig : IEntityTypeConfiguration<ServiceProviderBus>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ServiceProviderBus> builder)
        {
            
            
        }
    }
}
