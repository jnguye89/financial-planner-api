using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;
using FinancialPlanner.Services.Interfaces;

namespace FinancialPlanner.Services
{
    public class AuthService : IAuthService
    {
        private IUserService UserService { get; set; }
        private IJwtService JwtService { get; set; }

        public AuthService(IUserService userService, IJwtService jwtService)
        {
            UserService = userService;
            JwtService = jwtService;
        }

        public async Task<string> AuthorizeUser(AuthDto authDto)
        {
            var user = await UserService.GetUser(authDto.EmailAddress);
            var hashedPassword = user.PasswordHash;
            var salt = hashedPassword.Split(".")[0];
            var iterations = Int32.Parse(hashedPassword.Split(".")[2]);
            var isAuthenticated = HashService.Validate(authDto.Password, salt, iterations, hashedPassword);
            if (!isAuthenticated)
            {
                throw new Exception("Username or password is incorrect.");
            }
            var token = JwtService.GenerateSecurityToken(user.EmailAddress);
            return token;
        }
    }
}
