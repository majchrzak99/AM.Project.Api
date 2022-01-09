using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AM.Projekt.Service.Settings;
using Microsoft.IdentityModel.Tokens;

namespace AM.Projekt.Service.Services.Identity
{
    public partial class IdentityService
    {
        private string GenerateToken(string email, Guid userId)
        {
            JwtSecurityTokenHandler tokenHandler = new ();
            byte[] key = Encoding.ASCII.GetBytes(JwtTokenSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, email),
                    new Claim("Id", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}