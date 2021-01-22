﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.Dto;
using FinancialPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPlanner.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : Controller
    {
        private IAuthService AuthService { get; set; }
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken(AuthDto authDto)
        {
            var token = await AuthService.AuthorizeUser(authDto);
            return Ok(token);
        }
    }
}