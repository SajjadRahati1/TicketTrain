using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Refrences.Flight;

namespace Ticket.Persistance.Config.Flight
{
    public class AirLineConfig : IEntityTypeConfiguration<AirLine>
    {
        public void Configure(EntityTypeBuilder<AirLine> builder)
        {
            builder.Property(p => p.LogoUrl).HasMaxLength(300);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(300);
            builder.HasAlternateKey(p=>p.Code);
        }
    }
    
}
