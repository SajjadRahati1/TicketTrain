using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Refrences.Bus.Ticket;

namespace Ticket.Persistance.Config.Bus.Ticket
{
    public class TicketBusConfig : IEntityTypeConfiguration<TicketBus>
    {
        public void Configure(EntityTypeBuilder<TicketBus> builder)
        {
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.NationalCode).IsRequired();
            builder.HasIndex(p => p.NationalCode);
        }
    }
}
