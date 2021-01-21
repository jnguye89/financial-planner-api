using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int UserId);
        Task<UserDto> CreateUser(UserDto userDto);
    }
}
