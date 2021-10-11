using System;
using System.Threading.Tasks;
using FinancialPanner.Interfaces;
using FinancialPlanner.Dto;
using FinancialPlanner.Interfaces;

namespace FinancialPlanner.Services
{
    public class UserBalanceService : IUserBalanceService
    {
        private IUserBalanceRepository UserBalanceRepository { get; set; }

        public UserBalanceService(IUserBalanceRepository userBalanceRepository)
        {
            UserBalanceRepository = userBalanceRepository;
        }

        public async Task<UserBalanceDto> GetUserBalance(int userId)
        {
            return await UserBalanceRepository.GetUserBalance(userId);
        }
    }
}
