using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using onSite.Areas.Topo.Models;
using onSite.Context;
using onSite.Infrastructure;
using onSite.Repository;

namespace onSite
{
    public class Startup
    {
        protected IConfigurationRoot Configuration { get; }
        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(builder =>
            {
                string config = Configuration["ConnectionString"];
            });

            services.AddSingleton<UptimeService>();
            services.AddTransient<ITopoRepository, EFTopoRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if ((Configuration.GetSection("ShortCircuitMiddleware")?
                .GetValue<bool>("EnableBrowserCircuit")).Value)
            {
                app.UseMiddleware<BrowserTypeMiddleware>();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Topo}/{action=List}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
