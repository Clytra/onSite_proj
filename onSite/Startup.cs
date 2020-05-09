using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using onSite.Context;
using onSite.Infrastructure;
using onSite.Models;
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
                builder.UseSqlServer(config);
            });

            services.AddDbContext<AppIdentityDbContext>(builder =>
            {
                string config = Configuration["ConnectionStringIdentity"];
                builder.UseSqlServer(config);
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddTransient<ITopoRepository, EFTopoRepository>();
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

            app.UseAuthentication();

            app.UseRouting();


            app.UseMvc(routes =>
            {
                routes.MapRoute("Topo", "{area:exists}/{controller=Topo}/{action=List}");

                routes.MapRoute("Admin", "{area:exists}/{controller=Admin}/{action=TopoList}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
