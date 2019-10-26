using System.Collections.Generic;
using System.Linq;

namespace InvestmentPlanner.Models.DTOs
{
    public class InvestmentRecordDTO
    {
        /// <summary>
        /// Interest Gained From Investment
        /// </summary>
        public decimal Interest { get; set; }
        /// <summary>
        /// Total Amount Potentially Earned After Growth Calculation
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Contribution For The Year
        /// </summary>
        public decimal Contribution { get; set; }
        /// <summary>
        /// Record Year 
        /// </summary>
        public int Year { get; set; }
    }

    public class InvestmentResultDTO
    {
        /// <summary>
        /// Yearly Breakdown of Investment Growth
        /// </summary>
        public IList<InvestmentRecordDTO> Records { get; set; } = new List<InvestmentRecordDTO>();
        /// <summary>
        /// Initial Investment
        /// </summary>
        public decimal InitialInvestment { get; set; }
        /// <summary>
        /// How Much Contributions Shift Each Year
        /// </summary>
        public decimal AnnualContributionROC { get; set; }
        /// <summary>
        /// Total Years Vested
        /// </summary>
        public int Years { get; set; }
        /// <summary>
        /// Annual Percentage Rate of Return
        /// </summary>
        public decimal APR { get; set; }
        /// <summary>
        /// Principal; Amount Invested Prior To All Growth
        /// </summary>
        public decimal Principal => InitialInvestment + Records.Sum(v => v.Contribution);
        /// <summary>
        /// Total Investment Worth
        /// </summary>
        public decimal Total => Records.LastOrDefault()?.Total ?? InitialInvestment;
        /// <summary>
        /// Interest Growth Over Total Duration
        /// </summary>
        public decimal Interest => Records.Sum(v => v.Interest);
    }
}
