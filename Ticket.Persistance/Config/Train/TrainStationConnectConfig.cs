using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Train;
namespace Ticket.Persistance.Config.Train
{
    public class TrainStationConnectConfig : IEntityTypeConfiguration<TrainStationConnect>
    {
        public void Configure(EntityTypeBuilder<TrainStationConnect> builder)
        {
           
            builder.Property(p => p.SpaceBetween).IsRequired().HasColumnType("time(2)");
            
        }
    }
    
}
