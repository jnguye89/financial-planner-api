using System;
using System.Threading.Tasks;
using FinancialPlanner.Dto;
using FinancialPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPlanner.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService UserService { get; set; }
        private IJwtService JwtService { get; set; }

        public UserController(IUserService userService, IJwtService jwtService)
        {
            UserService = userService;
            JwtService = jwtService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await UserService.GetUser(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var user = await UserService.CreateUser(userDto);
            return Ok(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetRandomToken()
        {
            var token = JwtService.GenerateSecurityToken("jnguye89@gmail.com");
            return token;
        }
    }
}
