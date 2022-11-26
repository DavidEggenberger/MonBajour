using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.BaselAPI;
using WebAPI.Infrastructure;
using WebAPI.PlacesAPI;
using WebAPI.Share;

namespace WebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyBajourAPI", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddHttpClient<BaselAPIClient>(client =>
            {
                client.BaseAddress = new Uri("https://data.bs.ch/api/records/1.0/search/?");
            });

            services.AddSingleton<ShareContainer>();
            services.AddSingleton<BaselAPIDataBucket>();
            services.AddScoped<BaselAPIDataBucketService>();
            services.AddSingleton<GooglePlacesAPIClient>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["GoogleClientId"];
                options.ClientSecret = Configuration["GoogleClientSecret"];
            })
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = new TimeSpan(0, 60, 0);
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "AuthenticationCookie";
                options.LoginPath = "/Login";
                options.LogoutPath = "/User/Logout";
                options.SlidingExpiration = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.InjectStylesheet("/css/swaggerstyles.css");
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
            });

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
