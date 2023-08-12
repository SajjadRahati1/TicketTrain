using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Train;
namespace Ticket.Persistance.Config.Train
{
    public class TrainTravelConfig : IEntityTypeConfiguration<TrainTravel>
    {
        public void Configure(EntityTypeBuilder<TrainTravel> builder)
        {
            builder.Property(p => p.CoupeFacilities).HasMaxLength(2000);
            builder.Property(p => p.GeneralTrainFacilities).HasMaxLength(2000);
        }
    }
    
}
