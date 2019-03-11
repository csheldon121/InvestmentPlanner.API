using InvestmentPlanner.Repository;
using InvestmentPlanner.Repository.Contexts;
using InvestmentPlanner.Repository.Interfaces;
using InvestmentPlanner.Services;
using InvestmentPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPlanner.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IInvestmentRepository, InvestmentRepository>();

            services.AddDbContext<InvestmentContext>(o => o.UseSqlServer(Configuration.GetConnectionString(InvestmentContext.ConnStr)));

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.DTOs.InvestmentBasisDTO, Models.Entities.InvestmentBasisEntity>();
                cfg.CreateMap<Models.DTOs.InvestmentGoalDTO, Models.Entities.InvestmentGoalEntity>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
