using System;
using System.IdentityModel.Tokens.Jwt;

namespace FinancialPlanner.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateSecurityToken(string email);
        JwtSecurityToken DeserializeToken(string token);
    }
}
