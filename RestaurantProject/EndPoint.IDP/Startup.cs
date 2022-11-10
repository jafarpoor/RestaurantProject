using System;
using System.Linq;
using System.Reflection;
using Application.Interfaces;
using Domain.Users;
//using IdentityServer.Data.Seed;
//using IdentityServer.Models;
using IdentityServer4.Configuration;
//using IdentityServer4.EntityFramework.DbContexts;
//using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Contexts;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EndPoint.IDP
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public Startup(IConfiguration configuration , IHostingEnvironment Environment)
        {
            Configuration = configuration;
            this.Environment = Environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            string connectionString = "Data Source=.;Initial Catalog=RestaurantDb;Integrated Security=True;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
            );

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<DataBaseContext>()
            .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.UserInteraction.LoginUrl = "/Account/Login";
                options.UserInteraction.LogoutUrl = "/Account/Logout";
                options.Authentication = new AuthenticationOptions()
                {
                    CookieLifetime = TimeSpan.FromHours(10), // ID server cookie timeout set to 10 hours
                    CookieSlidingExpiration = true
                };
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                options.EnableTokenCleanup = true;
            })
            .AddAspNetIdentity<User>();

            
            
            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }
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
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
