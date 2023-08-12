using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trains = Ticket.Domain.Entities.Refrences.Train.Train;
namespace Ticket.Persistance.Config.Train
{
    public class TrainConfig : IEntityTypeConfiguration<Trains>
    {
        public void Configure(EntityTypeBuilder<Trains> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(400).IsRequired();
            builder.HasIndex(p => p.Name);

            builder.Property(p => p.Number).IsRequired();
            builder.Property(p => p.CompartmentType).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(2000);
            builder.Property(p => p.CoupeFacilities).HasMaxLength(2000);
            builder.Property(p => p.GeneralTrainFacilities).HasMaxLength(2000);
        }
    }
    
}
