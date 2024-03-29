﻿using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.Dto;
using FinancialPlanner.Interfaces;
using FinancialPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPlanner.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BillController : Controller
    {
        public IBillsService BillsService;
        public IUserService UserService;
        public IJwtService JwtService;

        public BillController(IBillsService billsService, IUserService userService, IJwtService jwtService)
        {
            BillsService = billsService;
            UserService = userService;
            JwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            var user = await UserService.GetUserByToken(await HttpContext.GetTokenAsync("access_token"));
            var bills = await BillsService.GetBillsByUserId(user.UserId);
            return Ok(bills);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBill(BillDto bill)
        {
            await BillsService.UpdateBill(bill);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(BillDto bill)
        {
            var user = await UserService.GetUserByToken(await HttpContext.GetTokenAsync("access_token"));
            bill.UserId = user.UserId;
            await BillsService.CreateBill(bill);
            return Ok();
        }

        [HttpDelete]
        [Route("{billId}")]
        public async Task<IActionResult> DeleteBill(int billId)
        {
            await BillsService.DeleteBill(billId);
            return Ok();
        }
    }
}
