using InvestmentPlanner.Models.DTOs;
using System.Collections.Generic;

namespace InvestmentPlanner.Services.Interfaces
{
    public interface IPlanService
    {
        IEnumerable<InvestmentResultDTO> CalculateInvestmentPotential(InvestmentBasisDTO basis);
        IEnumerable<InvestmentGoalResultDTO> CalculateForInvestmentGoal(InvestmentGoalDTO goal);
    }
}