using InvestmentPlanner.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvestmentPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly Services.Interfaces.IPlanService _planService;
        public PlanController(Services.Interfaces.IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("Basic")]
        public async Task<IActionResult> Plan(InvestmentBasisDTO investmentBasis)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _planService.CalculateInvestmentPotential(investmentBasis).ConfigureAwait(false));
        }

        [HttpPost("Goal")]
        public async Task<IActionResult> Goal(InvestmentGoalDTO goal)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _planService.CalculateForInvestmentGoal(goal).ConfigureAwait(false));
        }
    }
}