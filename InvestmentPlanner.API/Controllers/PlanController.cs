using InvestmentPlanner.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Plan(InvestmentBasisDTO investmentBasis)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_planService.CalculateInvestmentPotential(investmentBasis));
        }

        [HttpPost("Goal")]
        public IActionResult Goal(InvestmentGoalDTO goal)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_planService.CalculateForInvestmentGoal(goal));
        }
    }
}