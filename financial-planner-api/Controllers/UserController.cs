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
    [Route("api/[controller]")]
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
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var token = await UserService.CreateUser(userDto);
            var tokenDto = new TokenDto
            {
                Token = token
            };
            return Ok(tokenDto);
        }
    }
}
