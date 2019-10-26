using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPlanner.Models.Entities
{
    public class InvestmentBasisEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double InitialInvestment { get; set; }
        public double AnnualContributions { get; set; }
        public decimal AnnualContributionROC { get; set; }
        public int Years { get; set; }
        public decimal APR { get; set; }
        public DateTime Stamp { get; set; }
    }
}
