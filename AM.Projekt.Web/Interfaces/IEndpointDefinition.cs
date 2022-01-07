using Microsoft.AspNetCore.Builder;

namespace AM.Projekt.Web.Interfaces
{
    public interface IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app);
    }
}