using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Train;
namespace Ticket.Persistance.Config.Train
{
    public class GroupTrainTicketRefundRulesConfig : IEntityTypeConfiguration<GroupTrainTicketRefundRules>
    {
        public void Configure(EntityTypeBuilder<GroupTrainTicketRefundRules> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(300);

        }
    }
    
}
