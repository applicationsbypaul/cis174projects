using cis174projects.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace cis174projects
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
            services.AddMemoryCache();
            services.AddSession(options =>
            {
                //change idle timeout to 5 minutes - default is 20 minutes
                options.IdleTimeout = TimeSpan.FromSeconds(60 * 5);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDbContext<MovieContext>(options => options.UseSqlServer(@"Server=tcp:cis174pford.database.windows.net,1433;
                        Initial Catalog=CIS174;Persist Security Info=False;User ID=cis174;Password=Gemini99$;MultipleActiveResultSets=False;Encrypt=True;
                        TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddDbContext<ContactContext>(options => options.UseSqlServer(@"Server=tcp:cis174pford.database.windows.net,1433;
                        Initial Catalog=CIS174;Persist Security Info=False;User ID=cis174;Password=Gemini99$;MultipleActiveResultSets=False;Encrypt=True;
                        TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddDbContext<CountryContext>(options => options.UseSqlServer(@"Server=tcp:cis174pford.database.windows.net,1433;
                        Initial Catalog=CIS174;Persist Security Info=False;User ID=cis174;Password=Gemini99$;MultipleActiveResultSets=False;Encrypt=True;
                        TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddDbContext<TicketContext>(options => options.UseSqlServer(@"Server=tcp:cis174pford.database.windows.net,1433;
                        Initial Catalog=CIS174;Persist Security Info=False;User ID=cis174;Password=Gemini99$;MultipleActiveResultSets=False;Encrypt=True;
                        TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "custom",
                    pattern: "{controller}/{action}/game/{activeGame}/sport/{activeSport}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

                endpoints.MapControllerRoute(
                    name: "student",
                    pattern: "{controller=Home}/{action=Index}/{id?}/");

            });
        }
    }
}
