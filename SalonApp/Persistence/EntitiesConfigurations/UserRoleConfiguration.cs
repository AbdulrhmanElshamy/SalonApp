using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalonApp.Abstractions.Consts;

namespace SalonApp.Persistence.EntitiesConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        //Default Data
        builder.HasData(new IdentityUserRole<string>
        {
            UserId = DefaultUsers.Admin.Id,
            RoleId = DefaultRoles.Admin.Id
        });
    }
}