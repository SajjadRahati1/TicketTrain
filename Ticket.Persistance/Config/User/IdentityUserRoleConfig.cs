using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticket.Persistance.Config.User
{
    public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
        {
            builder.HasData(new IdentityUserRole<long>
            {
                RoleId = 1,
                UserId = 2
            });
            builder.HasData(new IdentityUserRole<long>
            {
                RoleId = 2,
                UserId = 2
            });
            builder.HasData(new IdentityUserRole<long>
            {
                RoleId = 1,
                UserId = 3
            });
            builder.HasData(new IdentityUserRole<long>
            {
                RoleId = 2,
                UserId = 3
            });
        }
    }
}
