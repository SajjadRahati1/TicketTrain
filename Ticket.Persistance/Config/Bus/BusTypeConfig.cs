using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Refrences.Bus;

namespace Ticket.Persistance.Config.Bus
{
    public class BusTypeConfig : IEntityTypeConfiguration<BusType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BusType> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(300);
            builder.Property(p=>p.SeatArrangement).HasMaxLength(1000);
            builder.Property(p => p.Model).HasMaxLength(300);
            //builder.Property(p => p.AllowableAmountLoad).HasMaxLength(300);
            
        }
    }
}
