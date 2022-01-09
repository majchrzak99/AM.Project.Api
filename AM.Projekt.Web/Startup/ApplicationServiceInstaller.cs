using AM.Projekt.Infrastructure;
using AM.Projekt.Service;
using AM.Projekt.Service.Services;
using AM.Projekt.Service.Services.Identity;
using AM.Projekt.Service.Services.User;
using AM.Projekt.Web.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.Startup
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddService(configuration);
            return services;
        }

        public WebApplication UseService(WebApplication app)
        {
            return app;
        }
    }
}