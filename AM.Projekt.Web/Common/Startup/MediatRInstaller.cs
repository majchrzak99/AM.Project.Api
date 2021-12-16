using System.Reflection;
using AM.Projekt.Web.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.Common.Startup
{
    public class MediatRInstaller : IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatRInstaller));
            return services;
        }

        public WebApplication UseService(WebApplication app)
        {
            return app;
        }
    }
}