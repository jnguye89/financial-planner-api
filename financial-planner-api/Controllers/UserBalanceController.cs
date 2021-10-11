using System.Threading.Tasks;
using FinancialPlanner.Interfaces;
using FinancialPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialPlanner.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserBalanceController : Controller
    {
        private IUserBalanceService UserBalanceService { get; set; }
        private IUserService UserService;
        private IJwtService JwtService;

        public UserBalanceController(IUserBalanceService userBalanceService, IUserService userService, IJwtService jwtService)
        {
            UserBalanceService = userBalanceService;
            UserService = userService;
            JwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBalance()
        {
            var user = await UserService.GetUserByToken(await HttpContext.GetTokenAsync("access_token"));
            var userBalance = await UserBalanceService.GetUserBalance(user.UserId);
            return Ok(userBalance);
        }
    }
}
