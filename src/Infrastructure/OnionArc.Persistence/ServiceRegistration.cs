using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArc.Application.Abstract;
using OnionArc.Persistence.Context;
using OnionArc.Persistence.Repositories;

namespace OnionArc.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Local"));
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
