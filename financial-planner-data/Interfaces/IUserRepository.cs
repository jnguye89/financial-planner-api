using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserAsync(int UserId);
        Task<UserDto> GetUserAsync(string email);
        Task<UserDto> CreateUserAsync(UserDto userDto);
    }
}
