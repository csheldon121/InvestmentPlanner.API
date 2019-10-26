using System.ComponentModel.DataAnnotations;

namespace InvestmentPlanner.Models.DTOs
{
    public class InvestmentBasisDTO
    {
        [Range(1, 10000000)]
        public decimal InitialInvestment { get; set; }
        [Range(1, 50000)]
        public decimal AnnualContributions { get; set; }
        [Range(0,2)]
        public decimal AnnualContributionROC { get; set; }
        [Range(1, 100)]
        public int Years { get; set; }
        [Range(0, 30)]
        public decimal APR { get; set; }
    }
}
