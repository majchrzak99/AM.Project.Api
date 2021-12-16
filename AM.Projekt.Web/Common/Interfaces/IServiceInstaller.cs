using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.Common.Interfaces
{
    public interface IServiceInstaller
    {
        public IServiceCollection AddServices(IServiceCollection services);
        public WebApplication UseService(WebApplication app);
    }
}