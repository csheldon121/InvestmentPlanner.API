using InvestmentPlanner.Models.Entities;
using System.Threading.Tasks;

namespace InvestmentPlanner.Repository.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<bool> SaveBasisAsync(InvestmentBasisEntity entity);
        Task<bool> SaveGoalsAsync(InvestmentGoalEntity entity);
    }
}