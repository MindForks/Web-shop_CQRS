﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WS_Core.Service.Dxos;
using MediatR;
using WS_Core.Service.Services;
using System;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Models;
using WS_Core.Data.Database;

namespace WS_Core.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "http://localhost:8080";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                      builder.WithOrigins("http://localhost:8080");
                                  });
            });
        
            services.AddScoped<ICustomDxos, CustomDxos>();
            services.AddScoped<IDatabase<Product>, ProductRepository>();
            services.AddScoped<IDatabase<Order>, OrderRepository>();


            var mediatRAssembly = AppDomain.CurrentDomain.Load("WS_Core.Service");
            services.AddMediatR(mediatRAssembly);

            services.AddLogging();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
