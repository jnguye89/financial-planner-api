using System;
using System.Threading.Tasks;
using FinancialPlanner.Data.Interfaces;
using FinancialPlanner.Dto;
using FinancialPlanner.Services.Interfaces;

namespace FinancialPlanner.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<UserDto> GetUser(int UserId)
        {
            return await UserRepository.GetUserAsync(UserId);
        }
    }
}
