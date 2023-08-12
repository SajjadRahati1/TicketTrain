using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class AirLineFinancialConfig : IEntityTypeConfiguration<AirLineFinancial>
    {
        public void Configure(EntityTypeBuilder<AirLineFinancial> builder)
        {
        }
    }
}
