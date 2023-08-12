using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buss = Ticket.Domain.Entities.Refrences.Bus.Bus;

namespace Ticket.Persistance.Config.Bus
{
    public class BusConfig : IEntityTypeConfiguration<Buss>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Buss> builder)
        {
            builder.Property(p=>p.NumberPlates).HasMaxLength(25);
            builder.HasIndex(p=>p.NumberPlates);
            builder.Property(p=>p.BusType).HasMaxLength(25);
        }
    }
}
