using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;

namespace OnionArc.Persistence.Seeds;

public class AppRoleSeed : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(new AppRole[]
        {
            new()
            {
                Id=1,
                Definition="Admin"
            },
            new()
            {
                Id=2,
                Definition="Member"
            }
        });
    }
}
