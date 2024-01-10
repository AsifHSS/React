using CRM_Portal.Interfaces;
using CRM_Portal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }
        // string abc= CSOModel.GetTitleName();
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IUsers, Users>();
            services.AddDbContext<CRM_PortalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Crm_PortalEntities")));
            services.AddMvc();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            // After app.UseStaticFiles()
            app.UseStaticFiles();
       
  // After app.UseEndpoints()
  //app.UseSpa(spa =>
  //{
  //    spa.Options.SourcePath = "client-app";
  //    if (env.IsDevelopment())
  //    {
  //        spa.UseReactDevelopmentServer(npmScript: "start");
  //    }
  //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
