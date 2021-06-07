using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Interfaces.IRepository;
using MISA.EShop.Core.Interfaces.IService;
using MISA.EShop.Core.Services;
using MISA.EShop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.EShop.WebAPI
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.EShop.WebAPI", Version = "v1" });
            });

            //Dependency Injection , tiêm.
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();

            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictService, DistrictService>();

            services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<IWardService, WardService>();

            services.AddScoped<IOrderBillRepository, OrderBillRepository>();
            services.AddScoped<IOrderBillService, OrderBillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.EShop.WebAPI v1"));
            }

            // sử dụng cors
            app.UseCors(x =>
            x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetPreflightMaxAge(TimeSpan.FromMinutes(10))
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
