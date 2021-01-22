using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthorizeUser(AuthDto authDto);
    }
}
