using System.ComponentModel.DataAnnotations;

namespace InvestmentPlanner.Models.DTOs
{
    public class InvestmentBasisDTO
    {
        [Range(1, 10000000)]
        public double InitialInvestment { get; set; }
        [Range(1, 50000)]
        public double MonthlyContributions { get; set; }
        [Range(1, 100)]
        public int Years { get; set; }
    }
}
