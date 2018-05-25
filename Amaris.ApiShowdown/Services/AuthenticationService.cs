using Amaris.ApiShowdown.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Amaris.ApiShowdown.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IConfiguration _configuration;

        private const int expireMinutes = 60;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SignToken(User user)
        {
            var secret = _configuration.GetSection("MyConfig").GetSection("Secret").Value;
            var configExpirationTime = _configuration.GetSection("MyConfig").GetSection("TokenExpiration").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.name),
                new Claim(ClaimTypes.Sid, user.id),
                new Claim(ClaimTypes.Role, user.role),
                new Claim("IsAdmin", user.role == "admin" ? "true" : "false")
            };

            var token = new JwtSecurityToken(
                issuer: "amaris.com",
                audience: "amaris.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(configExpirationTime)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
