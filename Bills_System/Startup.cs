using Bills.Data;
using Bills.Services;
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

namespace Bills
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
            services.AddControllersWithViews();

            services.AddSession(s => {
                s.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            services.AddDbContext<BillsDBcontext>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IItemDetailsRepository, ItemDetailsRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();

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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //area--admin
                endpoints.MapControllerRoute(
                 name: "Admin",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
