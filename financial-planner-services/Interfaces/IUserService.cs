using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int UserId);
        Task<UserDto> GetUser(string email);
        Task<UserDto> GetUserByToken(string token);
        Task<string> CreateUser(UserDto userDto);
    }
}
