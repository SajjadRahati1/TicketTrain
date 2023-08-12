using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities.Refrences.Train;
using Ticket.Domain.Entities.Refrences.Train.Ticket;

namespace Ticket.Persistance.Config.Train.Ticket
{
   
    public class TicketTrainReservationConfig : IEntityTypeConfiguration<TicketTrainReservation>
    {
        public void Configure(EntityTypeBuilder<TicketTrainReservation> builder)
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
