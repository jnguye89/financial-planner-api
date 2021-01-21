using System;
namespace FinancialPlanner.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateSecurityToken(string email);
    }
}
