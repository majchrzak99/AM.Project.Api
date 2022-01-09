using System;
using System.Linq;
using System.Reflection;
using AM.Projekt.Web.Interfaces;
using AM.Projekt.Web.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.Startup
{
    public class MapperInstaller : IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
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

        public WebApplication UseService(WebApplication app)
        {
            return app;
        }
    }
}