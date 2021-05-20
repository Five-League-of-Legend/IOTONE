
using IOT.Core.IRepository.Agent;
using IOT.Core.IRepository.Bargain;
using IOT.Core.IRepository.Colonel;
using IOT.Core.IRepository.Colonel.Brokerage;
using IOT.Core.IRepository.Colonel.ColonelGrade;
using IOT.Core.IRepository.Colonel.ColonelManagement;
using IOT.Core.IRepository.Colonel.GroupPurchase;
using IOT.Core.IRepository.Colonel.Path;
using IOT.Core.IRepository.CommissionRecord;
using IOT.Core.IRepository.RoleManage;
using IOT.Core.IRepository.Roles;
using IOT.Core.IRepository.Sett;
using IOT.Core.IRepository.SVIP;
using IOT.Core.IRepository.Users;
using IOT.Core.Repository.Agent;
using IOT.Core.Repository.Bargain;
using IOT.Core.Repository.Colonel;
using IOT.Core.Repository.Colonel.Brokerage;
using IOT.Core.Repository.Colonel.ColonelGrade;
using IOT.Core.Repository.Colonel.ColonelManagement;
using IOT.Core.Repository.Colonel.GroupPurchase;
using IOT.Core.Repository.Colonel.Path;
using IOT.Core.Repository.CommissionRecord;
using IOT.Core.Repository.RoleManage;
using IOT.Core.Repository.Roles;
using IOT.Core.Repository.Sett;
using IOT.Core.Repository.SVIP;
using IOT.Core.Repository.Users;
using IOT.Core.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.CommodityRepository;

namespace IOT.Core.Api
{
    using IOT.Core.IRepository.CommType;
    using IOT.Core.IRepository.Specification;
    using IOT.Core.Repository.Commodity;
    using IOT.Core.Repository.CommType;
    using IOT.Core.Repository.Specification;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IOT.Core.Api", Version = "v1" });
            });

            //--------------------------------------------------------------------------------------
            //ljh
            services.AddSingleton<IColonelRepository, ColonelRepository>();
            services.AddSingleton<IColonelManagementRepository, ColonelManagementRepository>();
            services.AddSingleton<IColonelGradeRepository, ColonelGradeRepository>();
            services.AddSingleton<IGroupPurchaseRepository, GroupPurchaseRepository>();
            services.AddSingleton<IPathRepository, PathRepository>();
            services.AddSingleton<IBrokerageRepository, BrokerageRepository>();
            //--------------------------------------------------------------------------------------



            //--------------------------------------------------------------------------------------
            //zxl
            services.AddSingleton<IAgentRepository, AgentRepository>();
            services.AddSingleton<ICommissionRecordRepository, CommissionRecordRepository>();
            services.AddSingleton<IRoleManageRepository, RoleManageRepository>();
            services.AddSingleton<ISettRepository, SettRepository>();
            services.AddSingleton<ISVIPRepository, SVIPRepository>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IRolesRepository, RolesRepository>();
            //--------------------------------------------------------------------------------------
            services.AddCors(options => 
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));



            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<ICommTypeRepository, CommTypeRepository>();
            services.AddScoped<ISpecificationRepository, SpecificationRepository>();

            services.AddCors(options => 
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IOT.Core.Api v1"));
            }
            app.UseCors("cors");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
