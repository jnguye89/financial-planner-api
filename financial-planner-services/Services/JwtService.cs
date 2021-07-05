using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinancialPlanner.Dto;
using FinancialPlanner.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FinancialPlanner.Services
{
    public class JwtService : IJwtService
    {
        private JwtSettingsDto JwtSettings { get; set; }

        public JwtService(IOptions<JwtSettingsDto> jwtSettings)
        {
            JwtSettings = jwtSettings.Value;
        }

        public string GenerateSecurityToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Issuer = "localhost",
                Audience = "localhost",
                Expires = DateTime.UtcNow.AddMinutes(JwtSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken DeserializeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var deserialized = handler.ReadJwtToken(token);
            var claim = deserialized.Claims;
            return deserialized;
        }
    }
}