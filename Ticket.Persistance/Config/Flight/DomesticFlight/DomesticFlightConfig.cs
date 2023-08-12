using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFlightt = Ticket.Domain.Entities.Refrences.Flight.DomesticFlight.DomesticFlight;
namespace Ticket.Persistance.Config.Flight.DomesticFlight
{
    public class DomesticFlightConfig : IEntityTypeConfiguration<DFlightt>
    {
        public void Configure(EntityTypeBuilder<DFlightt> builder)
        {
            //builder.Property(p=>p.)
        }
    }
}
