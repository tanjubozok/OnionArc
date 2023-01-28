using Microsoft.EntityFrameworkCore;
using OnionArc.Domain.Entities;
using OnionArc.Persistence.Configurations;
using OnionArc.Persistence.Seeds;

namespace OnionArc.Persistence.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        modelBuilder.ApplyConfiguration(new AppRoleSeed());
        modelBuilder.ApplyConfiguration(new AppUserSeed());
        modelBuilder.ApplyConfiguration(new CategorySeed());
        modelBuilder.ApplyConfiguration(new ProductSeed());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
}
