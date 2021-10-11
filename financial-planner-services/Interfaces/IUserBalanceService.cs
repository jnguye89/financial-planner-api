using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Interfaces
{
    public interface IUserBalanceService
    {
        Task<UserBalanceDto> GetUserBalance(int userId);
    }
}
