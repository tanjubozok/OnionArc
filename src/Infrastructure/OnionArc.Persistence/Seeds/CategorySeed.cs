using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;

namespace OnionArc.Persistence.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category[]
        {
            new()
            {
                Id= 1,
                Definition="Elektronik"
            },
            new()
            {
                Id= 2,
                Definition="Kitap"
            }
        });
    }
}
