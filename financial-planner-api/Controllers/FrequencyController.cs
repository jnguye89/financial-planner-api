using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialPlanner.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FrequencyController : Controller
    {
        public IFrequencyService FrequencyService;

        public FrequencyController(IFrequencyService frequencyService)
        {
            FrequencyService = frequencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFrequencies()
        {
            var frequencies = await FrequencyService.GetFrequencies();
            return Ok(frequencies);
        }
    }
}
