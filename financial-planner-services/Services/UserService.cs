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
        private IJwtService JwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            UserRepository = userRepository;
            JwtService = jwtService;
        }

        public async Task<UserDto> GetUser(int UserId)
        {
            return await UserRepository.GetUserAsync(UserId);
        }

        public async Task<UserDto> GetUser(string email)
        {
            return await UserRepository.GetUserAsync(email);
        }

        public async Task<string> CreateUser(UserDto userDto)
        {
            var salt = Salt.Create();
            var random = new Random();
            var iterations = random.Next(100, 10000);
            var hash = HashService.Create(userDto.Password, salt, iterations);
            userDto.PasswordHash = hash;
            await UserRepository.CreateUserAsync(userDto);
            return JwtService.GenerateSecurityToken(userDto.EmailAddress);
        }
    }
}
