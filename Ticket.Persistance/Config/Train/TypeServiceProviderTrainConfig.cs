using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Train;
namespace Ticket.Persistance.Config.Train
{
    public class TypeServiceProviderTrainConfig : IEntityTypeConfiguration<TypeServiceProviderTrain>
    {
        public void Configure(EntityTypeBuilder<TypeServiceProviderTrain> builder)
        {
            builder.Property(p=>p.Title).IsRequired().HasMaxLength(200);
            builder.HasAlternateKey(p => p.Title);
            builder.Property(p => p.Description).HasMaxLength(2000);
        }
    }
    
}
