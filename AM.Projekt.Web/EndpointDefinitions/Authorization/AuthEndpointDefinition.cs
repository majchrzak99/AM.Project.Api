using System;
using System.Net;
using AM.Projekt.Service.Services;
using AM.Projekt.Web.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.EndpointDefinitions.Authorization
{
    /// <summary>
    /// Authorization
    /// </summary>
    public class AuthEndpointDefinition : IEndpointDefinition
    {

        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/auth/test", Test);
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        private IResult Test(IUserService userService)
        {
            return Results.Ok(userService.Get(new Guid()));
        }
    }
}