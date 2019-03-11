using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPlanner.Models.DTOs
{
    public class InvestmentResultDTO
    {
        /// <summary>
        /// Interest Gained From Investment
        /// </summary>
        public double Growth { get; set; }
        /// <summary>
        /// Total Amount Potentially Earned After Growth Calculation
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// Principal; Amount Invested Prior To All Growth
        /// </summary>
        public double Principal { get; set; }
        /// <summary>
        /// Annual Percentage Rate of Return
        /// </summary>
        public double APR { get; set; }
        /// <summary>
        /// In Theory, The Average Of How Much The Investment May Grow Monthly Without Additional Investment
        /// </summary>
        public double FinalizedMonthlyGrowthRate { get; set; }
    }
}
