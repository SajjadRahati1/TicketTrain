using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Users;

namespace Ticket.Persistance.Config.User
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> b)
        {
            b.Property(p => p.EmailAddress).IsRequired(false);
            b.Property(p => p.PhoneNumber).IsRequired(true);
            b.Property(p => p.BirthDate).IsRequired(false);
            b.Property(p => p.Gender).IsRequired(false);
            b.Property(p => p.LastName)
                .IsRequired(false)
                .HasMaxLength(10);
            b.Property(p => p.NationalCode).IsRequired(false)
                .HasMaxLength(10);
            b.Property(p => p.FirstName).IsRequired(false)
                .HasMaxLength(250);

        }
    }
}
