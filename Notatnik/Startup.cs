using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notatnik.Models;

namespace Notatnik
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
                Configuration = config;
        }    

        private IConfiguration Configuration { get; set;}    
        
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllersWithViews();

            services.AddDbContext<NotatnikDbContext>(opts =>
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:NotatnikConnection"])
                );
            services.AddScoped<INotatnikRepository, EFNotatnikRepository>(); /*179*/
            services.AddRazorPages();
    
            services.AddServerSideBlazor();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute("catpage",
                    "{category}/Page{productPage:int}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page", "Page{productPage:int}",
                    new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("category", "{category}",
                    new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("pagination",
                    "Products/Page{productPage}",
                    new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}","/Admin/_Host");
            });
            SeedData.EnsurePopulated(app);

          
        }
    }
}
