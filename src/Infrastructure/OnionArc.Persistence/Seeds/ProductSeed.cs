using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;

namespace OnionArc.Persistence.Seeds;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(new Product[]
        {
            new()
            {
                Id = 1,
                Name="Laptop",
                Price=20000,
                Stock=100,
                CategoryId=1,
            },
            new()
            {
                Id = 2,
                Name="Macera",
                Price=800,
                Stock=1000,
                CategoryId=2,
            }
        });
    }
}
