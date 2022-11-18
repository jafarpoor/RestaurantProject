using Application.Baskets.FacadePattern;
using Application.Categories.FacadePattern;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.Interfaces.Categories;
using Application.Interfaces.Order;
using Application.Interfaces.Payments;
using Application.Orders.FacadePattern;
using Application.Payments.FacadePattern;
using Application.UriComposer;
using Application.Users.FacadePattern;
using AutoMapper;
using Domain.Users;
using Infrastructure.Api.ImageApi;
using Infrastructure.AutoMapperConfigs;
using Infrastructure.IdentityConfigs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site
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

            #region connectionString
            services.AddTransient<IDatabaseContext, DataBaseContext>();
            string connection = Configuration["ConnectionString:SqlServer"];
            services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));

            #endregion

            services.AddIdentityConfig(Configuration);
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromDays(360);
            });

            //Facade
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddTransient<ICategoryFacade, CategoryFacade>();
            services.AddTransient<IBasketFacade, BasketFacade>();
            services.AddTransient<IOrderFacade, OrderFacade>();
            services.AddTransient<IPaymentFacade, PaymentFacade>();

            //public
            services.AddTransient<IUriComposerService, UriComposerService>();

            //Image
            services.AddTransient<IImageUploadService, ImageUploadService>();

            //Mapper
            services.AddAutoMapper(typeof(UserMapperConfig));
            services.AddAutoMapper(typeof(BasketMapperConfig));
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

                 );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
