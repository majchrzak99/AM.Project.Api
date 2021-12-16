using AM.Projekt.Web.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AM.Projekt.Web.Common.Startup
{
    public class SwaggerInstaller : IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Description = "Api do projektu z Aplikacji mobilnych"
            }));

            return services;
        }

        public WebApplication UseService(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "Swagger";
                options.DocumentTitle = "Api do projektu z Aplikacji mobilnych";
            });
            return app;
        }
    }
}