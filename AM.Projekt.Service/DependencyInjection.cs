using System;
using System.Linq;
using System.Reflection;
using AM.Projekt.Domain.Entities;
using AM.Projekt.Infrastructure;
using AM.Projekt.Service.Mappings;
using AM.Projekt.Service.Services.Identity;
using AM.Projekt.Service.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserService, UserService>();
            
            var mapperConfigs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(concreteConfigs =>
                    typeof(IMappingConfig).IsAssignableFrom(concreteConfigs) && !concreteConfigs.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IMappingConfig>().ToList();

            foreach (IMappingConfig config in mapperConfigs)
            {
                config.CreateMap(Mapster.TypeAdapterConfig.GlobalSettings);
            }
            return services;
        }
    }
}