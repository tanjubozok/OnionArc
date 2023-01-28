using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;

namespace OnionArc.Persistence.Seeds;

public class AppUserSeed : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasData(new AppUser[]
        {
            new()
            {
                Id= 1,
                Username="admin",
                Password="1",
                AppRoleId=1
            },
            new()
            {
                Id= 2,
                Username="member",
                Password="1",
                AppRoleId=2
            }
        });
    }
}
