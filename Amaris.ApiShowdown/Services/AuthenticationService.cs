using Amaris.ApiShowdown.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
            var symmetricKey = Convert.FromBase64String(secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Sid, user.id)
                    }),

                Expires = now.AddMinutes(Convert.ToInt32(configExpirationTime)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }
}
