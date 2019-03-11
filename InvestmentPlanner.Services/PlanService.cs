using InvestmentPlanner.Models.DTOs;
using System.Collections.Generic;

namespace InvestmentPlanner.Services
{
    public class PlanService : Interfaces.IPlanService
    {
        public IEnumerable<InvestmentResultDTO> CalculateInvestmentPotential(InvestmentBasisDTO basis)
        {
            var possibleReturns = new List<InvestmentResultDTO>();

            for (int i = 1; i <= 10; i++)
            {
                var investment = new InvestmentResultDTO
                {
                    Principal = basis.InitialInvestment + (basis.MonthlyContributions * basis.Years * 12),
                    Total = basis.InitialInvestment,
                    APR = i
                };

                for (int j = 0; j < basis.Years; j++)
                {
                    var yearlyTotal = investment.Total + (basis.MonthlyContributions * 12);
                    var yearlyGrowth = yearlyTotal * (investment.APR / 100);
                    investment.Growth += yearlyGrowth;
                    investment.Total = yearlyGrowth + yearlyTotal;
                }

                investment.FinalizedMonthlyGrowthRate = investment.Total * (investment.APR / 100) / 12;

                possibleReturns.Add(investment);
            }

            return possibleReturns;
        }

        public IEnumerable<InvestmentGoalResultDTO> CalculateForInvestmentGoal(InvestmentGoalDTO goal)
        {
            var result = new List<InvestmentGoalResultDTO>();
            
            for (int i = 1; i <= 5; i++)
            {
                for (double j = 1; j <= 10; j++)
                {
                    var investmentGoal = new InvestmentGoalResultDTO
                    {
                        APR = j,
                        YearsInvested = i * 10
                    };

                    var mpr = j / 100d / 12d;
                    var months = investmentGoal.YearsInvested * 12;
                    var total = goal.MonthlyWithdrawAmount / mpr * 1.2;

                    investmentGoal.TotalExpectedInvestment = total;
                    investmentGoal.MonthlyInvestmentRequired = (total - goal.InitialInvestment) / months;

                    result.Add(investmentGoal);
                }
            }

            return result;
        }
    }
}
