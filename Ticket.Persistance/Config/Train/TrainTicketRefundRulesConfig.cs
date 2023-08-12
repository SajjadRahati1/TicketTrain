using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Train;
namespace Ticket.Persistance.Config.Train
{
    public class TrainTicketRefundRulesConfig : IEntityTypeConfiguration<TrainTicketRefundRules>
    {
        public void Configure(EntityTypeBuilder<TrainTicketRefundRules> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Start_AfterIssuanceTicket).HasColumnType("time(2)");
            builder.Property(p => p.End_AfterIssuanceTicket).HasColumnType("time(2)");
            builder.Property(p => p.Start_BeforeFlight).HasColumnType("time(2)");
            builder.Property(p => p.End_BeforeFlight).HasColumnType("time(2)");
        }
    }
    
}
