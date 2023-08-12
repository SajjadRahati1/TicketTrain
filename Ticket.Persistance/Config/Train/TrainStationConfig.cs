using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Train;
namespace Ticket.Persistance.Config.Train
{
    public class TrainStationConfig : IEntityTypeConfiguration<TrainStation>
    {
        public void Configure(EntityTypeBuilder<TrainStation> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(400).IsRequired();
            builder.HasIndex(p => p.CityId);
            builder.HasAlternateKey(p => new { p.Name, p.CityId });

            builder.Property(p => p.Description).HasMaxLength(2000);
            
        }
    }
    
}
