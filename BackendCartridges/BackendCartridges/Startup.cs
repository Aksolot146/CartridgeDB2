using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCartridges.Services;
using BackendCartridges.Models;
using RabbitMQ.Client;
using EasyNetQ;

namespace BackendCartridges
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:44312", "https://localhost:44371").AllowAnyHeader().AllowAnyMethod();
                });
            });
            //services.AddControllersWithViews();

            services.AddTransient<DepartmentService>();
            services.AddTransient<EmployeeService>();
            services.AddTransient<MechanicService>();
            services.AddTransient<CartridgeTypeService>();
            services.AddTransient<RepairService>();
            services.AddTransient<CartridgeService>();
            services.AddTransient<EventService>();
            services.AddTransient<StatusService>();
            services.AddControllers();
            services.AddOpenApiDocument();

            //string rabbitmqConnectionString = "host=host.docker.internal;username=guest;password=guest;timeout=60";
            //var bus = RabbitHutch.CreateBus(rabbitmqConnectionString);
            //services.AddSingleton(bus);
            //services.AddHostedService<BackgroundServices.UserEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
