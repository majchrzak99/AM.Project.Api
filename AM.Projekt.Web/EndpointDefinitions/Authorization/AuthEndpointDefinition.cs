using System;
using System.Net;
using System.Threading.Tasks;
using AM.Projekt.Domain.Entities;
using AM.Projekt.Service.Dtos.Identity;
using AM.Projekt.Service.Services;
using AM.Projekt.Service.Services.Identity;
using AM.Projekt.Service.Services.User;
using AM.Projekt.Web.DataContracts.Requests.Authorization;
using AM.Projekt.Web.DataContracts.Responses.Authorization;
using AM.Projekt.Web.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Projekt.Web.EndpointDefinitions.Authorization
{
    /// <summary>
    /// Authorization
    /// </summary>
    [Authorize]

    public class AuthEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/register", Register);
            app.MapPost("/login", Login);
            app.MapPost("/test", Test);
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RegisterResponse))]
        [AllowAnonymous]
        private async Task<IResult> Register([FromBody] RegisterRequest request, IIdentityService identityService)
        {
            RegisterInput registerInput = request.Adapt<RegisterInput>();
            RegisterResult registerResult = await identityService.Register(registerInput);

            RegisterResponse response = registerResult.Adapt<RegisterResponse>();
            return Results.Ok(response);
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        [AllowAnonymous]
        private async Task<IResult> Login([FromBody] LoginRequest request, IIdentityService identityService)
        {
            LoginInput input = request.Adapt<LoginInput>();
            LoginResult result = await identityService.Login(input);

            LoginResponse response = result.Adapt<LoginResponse>();
            return Results.Ok(response);
        }
        
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [Authorize(Roles = "Admin")]
        private async Task<IResult> Test()
        {
            return Results.Ok("Test");
        }
    }
}