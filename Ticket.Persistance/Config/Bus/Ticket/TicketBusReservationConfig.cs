using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Bus.Ticket;

namespace Ticket.Persistance.Config.Bus.Ticket
{
    public class TicketBusReservationConfig : IEntityTypeConfiguration<TicketBusReservation>
    {
        public void Configure(EntityTypeBuilder<TicketBusReservation> builder)
        {
            builder.Property(p => p.TicketNumber).IsRequired();
            builder.Property(p => p.OrderNumber).IsRequired();
            builder.HasAlternateKey(p => p.TicketNumber);
            builder.HasAlternateKey(p => p.OrderNumber);

            builder.Property(p => p.SendOtherInformationToPhoneNumber).HasMaxLength(20);
            builder.Property(p => p.SendOtherInformationToEmail).HasMaxLength(250);
        }
    }
}
