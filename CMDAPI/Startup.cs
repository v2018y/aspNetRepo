using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;

namespace CMDAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
              // This line Added This Services to Eureka Server
            services.AddLogging();
            services.AddDiscoveryClient(Configuration);
            // This Line Enable Database Connections
            services.AddDbContext<CommandContext> (opt => opt.UseSqlServer(Configuration["Data:CommandAPIConnection:ConnectionString"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // This Line Added Swagger Ui Informations
            services.AddSwaggerGen(c=>{
                c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo{
                    Title="V & Y Company Hotel Api",
                    Description="This is Hotel Api, For Hotel Managment Software.",
                    Version="v0.1",
                    Contact=new Microsoft.OpenApi.Models.OpenApiContact{
                        Email="v2018y@gmail.com",
                        Name="V & Y Soft. Tech. Pvt. Ltd."
                    }
                    });
            });
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
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
            // This Loaded Static Page Project Start
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            // This Line Enable The Swagger UI For The Our Api
            app.UseSwagger();
            app.UseSwaggerUI(c=>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json","V & Y Company Hotel Api");
            });

            // This Line Code Enable Discovery Client 
             app.UseDiscoveryClient();

        }
    }
}
