using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight.DomesticFlight;
namespace Ticket.Persistance.Config.Flight.DomesticFlight
{
    public class TicketDomesticFlightConfig : IEntityTypeConfiguration<TicketDomesticFlight>
    {
        public void Configure(EntityTypeBuilder<TicketDomesticFlight> builder)
        {
            builder.HasAlternateKey(p => new { p.PassengerId, p.ReservationId });
            builder.Property(p => p.TicketNumber)
                .HasComputedColumnSql(
                $"'DF-'+ " +
                $"CONVERT(NVARCHAR(4),YEAR(GETDATE()))+'-'+" +
                $"CONVERT(NVARCHAR(4),MONTH(GETDATE()))+'-'+" +
                $"CONVERT(NVARCHAR(4),DAY(GETDATE()))+'-'+" +
                $"[Id]")
                .HasMaxLength(50);
            //builder.HasIndex(p => p.TicketNumber).IsUnique();
        }
    }
}
