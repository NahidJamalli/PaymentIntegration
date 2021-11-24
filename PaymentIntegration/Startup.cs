using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payment.DumDumPay.Interfaces;
using Refit;

namespace PaymentIntegration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddRefitClient<IDumDumPayApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://dumdumpay.site/api");
                    c.DefaultRequestHeaders.Add("Mechant-Id", Configuration["Credentials:Merchant-Id"]);
                    c.DefaultRequestHeaders.Add("Secret-Key", Configuration["Credentials:Secret-Key"]);
                });

            services.AddAutoMapper(typeof(MapperProfile));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(2);
            });
            
            services.AddDistributedMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}