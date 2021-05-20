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
using IOT.Core.IRepository.Activity;
using IOT.Core.Repository.Activity;
using IOT.Core.IRepository.SeckillCom;
using IOT.Core.Repository.SeckillCom;
using IOT.Core.IRepository.Bargain;
using IOT.Core.Repository.Bargain;

namespace IOT.Core.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IOT.Core.Api", Version = "v1" });
            });

            services.AddSingleton<IActivityRepository, ActivityRepository>();

            services.AddSingleton<IColonelRepository, ColonelRepository>();

            services.AddSingleton<IColonelManagementRepository, ColonelManagementRepository>();

            services.AddSingleton<IColonelGradeRepository, ColonelGradeRepository>();

            services.AddSingleton<IGroupPurchaseRepository, GroupPurchaseRepository>();

            services.AddSingleton<IPathRepository, PathRepository>();

            services.AddSingleton<IBrokerageRepository, BrokerageRepository>();


            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ISeckillComRepository, SeckillComRepository>();
            services.AddScoped<IBargainRepository,BargainRepository>();
            


            services.AddCors(options => options.AddPolicy("cors", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
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
