using Application.Categories.FacadePattern;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Application.Interfaces.Users;
using Application.UriComposer;
using Application.Users.Commands.Token;
using Application.Users.FacadePattern;
using Infrastructure.Api.ImageApi;
using Infrastructure.AutoMapperConfigs;
using Infrastructure.IdentityConfigs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPoint.API
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

            services.AddControllers();
            #region connectionString
            services.AddTransient<IDatabaseContext, DataBaseContext>();
            string connection = Configuration["ConnectionString:SqlServer"];
            services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));

            services.AddIdentityConfig(Configuration);

            //Facade
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddTransient<ICategoryFacade, CategoryFacade>();

            //public
            services.AddTransient<IUriComposerService, UriComposerService>();

            //Image
            services.AddTransient<IImageUploadService, ImageUploadService>();

            //Mapper
            services.AddAutoMapper(typeof(UserMapperConfig));
            //
            #endregion

            services.AddScoped<ICreatUserTokenService, CreatUserTokenService>();
            services.AddScoped<ITokenValidator, TokenValidator>();

            services.AddAuthentication(p => {
                p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                p.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["JWtConfig:issuer"],
                    ValidAudience = Configuration["JWtConfig:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWtConfig:Key"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                };
                configureOptions.SaveToken = true; // HttpContext.GetTokenAsunc();
                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        //log 
                        //........
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        var TokenValidate = context.HttpContext.RequestServices.GetRequiredService<ITokenValidator>();
                        return TokenValidate.Execute(context);
                    },
                    OnChallenge = context =>
                    {
                        return Task.CompletedTask;

                    },
                    OnMessageReceived = context =>
                    {
                        return Task.CompletedTask;

                    },
                    OnForbidden = context =>
                    {
                        return Task.CompletedTask;

                    }
                };

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EndPoint.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EndPoint.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
