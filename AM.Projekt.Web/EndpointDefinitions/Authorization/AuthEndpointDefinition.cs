using System.Net;
using AM.Projekt.Web.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.Projekt.Web.EndpointDefinitions.Authorization
{
    public class AuthEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/auth/test", Test);
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        private IResult Test()
        {
            return Results.Ok("test");
        }
    }
}