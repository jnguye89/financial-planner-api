using System;
using System.Threading.Tasks;
using FinancialPlanner.Data.Interfaces;
using FinancialPlanner.Dto;
using FinancialPlanner.Services.Interfaces;
//using FinancialPlanner.Data.Models;
//using FinancialPlanner.Data.Repositories;

namespace FinancialPlanner.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public UserDto GetUser(int UserId)
        {
            return UserRepository.GetUserAsync(UserId);
        }
    }
}
