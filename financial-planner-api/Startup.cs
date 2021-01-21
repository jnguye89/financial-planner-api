//using FinancialPlanner.Data.Data;
using System.Reflection;
using AutoMapper;
using FinancialPlanner.Api.Middleware;
using FinancialPlanner.Data.Data;
using FinancialPlanner.Data.Interfaces;
using FinancialPlanner.Data.Mappers;
using FinancialPlanner.Data.Repositories;
using FinancialPlanner.Dto;
using FinancialPlanner.Services;
using FinancialPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinancialPlanner.Api
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
            services.AddDbContext<FinancialPlannerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<JwtSettingsDto>(Configuration.GetSection("JwtSettings"));

            services.AddControllers();
            services.AddTokenAuthentication(Configuration);
            services.AddAutoMapper(new[]
            {
                Assembly.GetAssembly(typeof(Startup)),
                Assembly.GetAssembly(typeof(UserMapper))
            });
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IJwtService, JwtService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
