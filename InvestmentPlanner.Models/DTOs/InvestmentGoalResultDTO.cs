using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPlanner.Models.DTOs
{
    public class InvestmentGoalResultDTO
    {
        public double APR { get; set; }
        public double MonthlyInvestmentRequired { get; set; }
        public double TotalExpectedInvestment { get; set; }
        public double YearsInvested { get; set; }
    }
}
