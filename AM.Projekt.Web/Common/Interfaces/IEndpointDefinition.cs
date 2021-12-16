using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.Common.Interfaces
{
    public interface IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app);
    }
}