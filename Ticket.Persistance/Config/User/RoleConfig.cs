using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.Domain.Entities.Users;
using Ticket.Domain.Enums;

namespace Ticket.Persistance.Config.User
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> b)
        {
            b.HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            b.HasData(new Role { Id = 2, Name = nameof(UserRoles.Customer) });
        }
    }
}
