using InvestmentPlanner.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPlanner.Services.Interfaces
{
    public interface IPlanService
    {
        Task<IEnumerable<InvestmentResultDTO>> CalculateInvestmentPotential(InvestmentBasisDTO basis);
        Task<IEnumerable<InvestmentGoalResultDTO>> CalculateForInvestmentGoal(InvestmentGoalDTO goal);
    }
}