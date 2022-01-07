using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.Interfaces
{
    public interface IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services,IConfiguration configuration);
        public WebApplication UseService(WebApplication app);
    }
}