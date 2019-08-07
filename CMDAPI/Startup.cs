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

namespace CMDAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
            // This Line Enable The Swagger UI For The Our Api
            app.UseSwagger();
            app.UseSwaggerUI(c=>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json","V & Y Company Hotel Api");
            });
        }
    }
}
