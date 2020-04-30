using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using onSite.Areas.Topo.Models;
using onSite.Context;
using onSite.Infrastructure;
using onSite.Repository;
using onSite.Repository.Topo;

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
                builder.UseSqlServer(config);
            });

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddSingleton<UptimeService>();
            services.AddTransient<ITopoRepository, EFTopoRepository>();
            services.AddTransient<IRouteRepository, EFRouteRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
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


            app.UseMvc(routes =>
            {
                routes.MapRoute("Topo", "{area:exists}/{controller=Topo}/{action=List}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
