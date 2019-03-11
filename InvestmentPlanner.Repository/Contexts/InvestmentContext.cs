using InvestmentPlanner.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPlanner.Repository.Contexts
{
    public class InvestmentContext : DbContext
    {
        public static readonly string ConnStr = "InvestmentPlanner";
        public DbSet<InvestmentGoalEntity> InvestmentGoals { get; set; }
        public DbSet<InvestmentBasisEntity> InvestmentBases { get; set; }

        public InvestmentContext(DbContextOptions<InvestmentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
