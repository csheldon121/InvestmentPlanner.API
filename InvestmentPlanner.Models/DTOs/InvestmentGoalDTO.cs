using System.ComponentModel.DataAnnotations;

namespace InvestmentPlanner.Models.DTOs
{
    public class InvestmentGoalDTO
    {
        [Range(0, 10000000)]
        public double InitialInvestment { get; set; }
        [Range(1, 20000)]
        public double MonthlyWithdrawAmount { get; set; }
    }
}
