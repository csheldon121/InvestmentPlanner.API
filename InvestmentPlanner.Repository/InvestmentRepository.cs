using InvestmentPlanner.Models.Entities;
using System;
using System.Threading.Tasks;

namespace InvestmentPlanner.Repository
{
    public class InvestmentRepository : Interfaces.IInvestmentRepository
    {
        private readonly Contexts.InvestmentContext _investmentContext;
        public InvestmentRepository(Contexts.InvestmentContext investmentContext)
        {
            _investmentContext = investmentContext;
        }

        public async Task<bool> SaveBasisAsync(InvestmentBasisEntity entity)
        {
            entity.Stamp = DateTime.UtcNow;
            await _investmentContext.InvestmentBases.AddAsync(entity).ConfigureAwait(false);
            return (await _investmentContext.SaveChangesAsync().ConfigureAwait(false)) > 0;            
        }

        public async Task<bool> SaveGoalsAsync(InvestmentGoalEntity entity)
        {
            entity.Stamp = DateTime.UtcNow;
            await _investmentContext.InvestmentGoals.AddAsync(entity).ConfigureAwait(false);
            return (await _investmentContext.SaveChangesAsync().ConfigureAwait(false)) > 0;
        }
    }
}
