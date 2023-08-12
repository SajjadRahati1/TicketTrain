using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Refrences.Train;
namespace Ticket.Persistance.Config.Train
{
    public class CompartmentConfig : IEntityTypeConfiguration<Compartment>
    {
        public void Configure(EntityTypeBuilder<Compartment> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(300);
        }
    }

  
    
}
