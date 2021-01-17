using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserAsync(int UserId);
    }
}
