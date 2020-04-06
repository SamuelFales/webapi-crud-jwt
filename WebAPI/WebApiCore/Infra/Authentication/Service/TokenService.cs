using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiCore.Infra.Authentication.Interfaces;
using WebApiCore.Infra.Configuration;
using WebApiCore.Models;

namespace WebApiCore.Infra.Authentication.Service
{
    public class TokenService : ITokenService
    {
        private readonly AppConfig _config;
        public TokenService(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }
        public string GenerateJSONWebToken(Users users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Token.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, users.UserId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config.Token.Issuer,
                audience: _config.Token.Issuer,
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            var encodingtoken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodingtoken;

        }
    }
}
