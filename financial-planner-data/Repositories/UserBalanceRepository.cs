using System;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPanner.Interfaces;
using FinancialPlanner.Data.Data;
using FinancialPlanner.Dto;
using Microsoft.EntityFrameworkCore;

namespace FinancialPanner.Repositories
{
    public class UserBalanceRepository : IUserBalanceRepository
    {
        public FinancialPlannerContext DbContext;
        public IMapper Mapper;

        public UserBalanceRepository(FinancialPlannerContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<UserBalanceDto> GetUserBalance(int userId)
        {
            var userBalance = await DbContext.UserBalances.FirstOrDefaultAsync(ub => ub.UserId == userId);
            return Mapper.Map<UserBalanceDto>(userBalance);
        }
    }
}
