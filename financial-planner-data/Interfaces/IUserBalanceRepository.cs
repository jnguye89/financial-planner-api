using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPanner.Interfaces
{
    public interface IUserBalanceRepository
    {
        Task<UserBalanceDto> GetUserBalance(int userId);
    }
}
