using System.Text;
using AM.Projekt.Domain.Entities;
using AM.Projekt.Service.Settings;
using AM.Projekt.Web.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AM.Projekt.Web.Startup
{
    public class AuthorizationInstaller : IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UserManager<ApplicationUser>>();

            var jwtSettings = new JwtTokenSettings();
            configuration.GetSection("JwtBearerSettings").Bind(jwtSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtTokenSettings.Secret)),
                    ValidateIssuer = true,
                    ValidIssuer = JwtTokenSettings.Issuer,
                    ValidAudience = JwtTokenSettings.Issuer,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    RequireExpirationTime = false
                    
                };
            });

            services.AddAuthorization();
            return services;
        }

        public WebApplication UseService(WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}