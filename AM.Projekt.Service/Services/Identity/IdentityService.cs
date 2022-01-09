using System;
using System.Linq;
using System.Threading.Tasks;
using AM.Projekt.Domain.Entities;
using AM.Projekt.Domain.Interfaces;
using AM.Projekt.Service.Dtos.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace AM.Projekt.Service.Services.Identity
{
    public interface IIdentityService
    {
        Task<RegisterResult> Register(RegisterInput registerInput);
        Task<LoginResult> Login(LoginInput loginInput);
    }

    public partial class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;

        public IdentityService(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<RegisterResult> Register(RegisterInput registerInput)
        {
            try
            {
                var user = registerInput.Adapt<ApplicationUser>();

                IdentityResult userResult = await _userManager.CreateAsync(user, registerInput.Password);

                _dbContext.SaveChanges();
                RegisterResult result = new()
                {
                    Succeded = userResult.Succeeded,
                    Errors = userResult.Errors.Select(x => x.Description)
                };
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<LoginResult> Login(LoginInput loginInput)
        {
            var user = await _userManager.FindByEmailAsync(loginInput.Email);
            if (user == null)
            {
                return new LoginResult
                {
                    Succeded = false,
                    Errors = new[] { "User not found" }
                };
            }

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginInput.Password);
            if (!isPasswordCorrect)
            {
                return new LoginResult
                {
                    Succeded = false,
                    Errors = new[] { "Bad password" }
                };
            }

            return new LoginResult()
            {
                Succeded = true,
                Token = GenerateToken(user.Email, user.Id)
            };
        }
    }
}