using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Users;

public class PassengerConfig : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> b)
    {
        b.Property(p => p.CountryBirthId).IsRequired(false);
        b.Property(p => p.PassportNumber).HasMaxLength(100).IsRequired(false);
        b.Property(p => p.En_FirstName).HasMaxLength(250).IsRequired(false);
        b.Property(p => p.En_LastName).HasMaxLength(250).IsRequired(false);
        b.Property(p => p.ExpireDatePassport).IsRequired(false);
        b.Property(p => p.UserId).IsRequired();
        b.HasIndex(p => p.PassportNumber).IsUnique();
    }
}
