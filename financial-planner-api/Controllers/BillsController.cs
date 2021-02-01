using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPlanner.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BillsController : Controller
    {
        [HttpGet]
        public IActionResult GetBills()
        {
            var result = new BillDto[]
            {
                new BillDto
                {
                    BillId = 1,
                    Description = "Capital One",
                    Frequency = new FrequencyDto
                    {
                        FrequencyId = 1,
                        Description = "monthly"
                    }
                },
                new BillDto
                {
                    BillId = 2,
                    Description = "Nissan",
                    Frequency = new FrequencyDto
                    {
                        FrequencyId = 1,
                        Description = "monthly"
                    }
                }
            };
            return Ok(result);
        }
    }
}
