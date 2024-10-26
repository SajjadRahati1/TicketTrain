using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Common;
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
            b.HasData(new Person()
            {
                EmailAddress = "Sajadrahaty2@gmail.com",
                BirthDate = "1380/03/31".ToMiladi(),
                Gender = Domain.Enums.Gender.Man,
                FirstName = "سجاد",
                Id = 1,
                IsRemoved = false,
                LastName = "راحتی",
                NationalCode = "1250635658",
                PhoneNumber = "09339799317"
            });
        }
    }
}
