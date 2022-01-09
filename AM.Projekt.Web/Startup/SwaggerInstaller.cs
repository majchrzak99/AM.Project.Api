using System;
using System.Collections.Generic;
using AM.Projekt.Web.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AM.Projekt.Web.Startup
{
    public class SwaggerInstaller : IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Description = "Api do projektu z Aplikacji mobilnych"
                    }
                );
                OpenApiSecurityScheme bearerScheme = new()
                {
                    Description = "Jwt Bearer token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                };
                options.AddSecurityDefinition("Bearer", bearerScheme);

                OpenApiSecurityRequirement securityRequirements = new()
                {
                    { bearerScheme, Array.Empty<string>() }
                };

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                        },
                        new List<string>()
                    }
                });
            });

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