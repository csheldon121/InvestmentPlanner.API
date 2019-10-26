using InvestmentPlanner.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPlanner.Services
{
    public class PlanService : Interfaces.IPlanService
    {
        private readonly Repository.Interfaces.IInvestmentRepository _investmentRepository;
        public PlanService(Repository.Interfaces.IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<InvestmentResultDTO> CalculateInvestmentPotential(InvestmentBasisDTO basis)
        {
            var result = AutoMapper.Mapper.Map<InvestmentResultDTO>(basis);

            for (int i = 1; i <= result.Years; i++)
            {
                var record = new InvestmentRecordDTO { Year = i, Contribution = basis.AnnualContributions };

                record.Contribution += record.Contribution * (result.AnnualContributionROC / 100) * (i - 1);
                record.Interest = (result.Total + record.Contribution) * (result.APR / 100);
                record.Total = result.Total + record.Contribution + record.Interest;

                result.Records.Add(record);
            }

            var basisEntity = AutoMapper.Mapper.Map<Models.Entities.InvestmentBasisEntity>(basis);
            await _investmentRepository.SaveBasisAsync(basisEntity).ConfigureAwait(false);

            return result;
        }

        public async Task<IEnumerable<InvestmentGoalResultDTO>> CalculateForInvestmentGoal(InvestmentGoalDTO goal)
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

            var goalEntity = AutoMapper.Mapper.Map<Models.Entities.InvestmentGoalEntity>(goal);
            await _investmentRepository.SaveGoalsAsync(goalEntity).ConfigureAwait(false);

            return result;
        }
    }
}
