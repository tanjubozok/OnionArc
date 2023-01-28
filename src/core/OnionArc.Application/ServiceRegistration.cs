using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArc.Application.Mappings;
using System.Reflection;

namespace OnionArc.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(op =>
        {
            op.AddProfiles(new List<Profile>()
            {
                new CategoryProfile(),

            });
        });
    }
}
