using System;
using FinancialPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPlanner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            return Ok(UserService.GetUser(userId));
        }
    }

    public class User
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
