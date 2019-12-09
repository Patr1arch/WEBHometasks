using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebHometask3._3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/Demidovich", formulas =>
            {
                formulas.Map("/1", Demidovich_1);
                formulas.Map("/2", Demidovich_2);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });
        }

        private static void Demidovich_1(IApplicationBuilder app)
        {
            int x = 7;
            int n = 10;
            double z = 0.0;
            app.Use(async (context, next) =>
            {
                z = (Math.Round((Math.Pow(x - Math.Sqrt(Math.Pow(x, 2) - 1), n) + Math.Pow(x + Math.Sqrt(Math.Pow(x, 2) - 1), n)) / Math.Pow(x, n), 2));
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"((x - sqrt(x ^ 2 - 1) ) ^ n + (x + sqrt(x ^ 2 - 1)) ^ n) / x ^ n = {z}, where x = {x}, n = {n}");
            });
        }

        private static void Demidovich_2(IApplicationBuilder app)
        {
            int a = 15;
            int x = 5;
            double y = 0;
            app.Use(async (content, next) =>
            {
                y = Math.Atan((a - 2*x)/(2 * Math.Sqrt(a * x - x * x)));
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Arctg( (a - 2*x) / (2 * Math.Sqrt(a * x - x * x)) ) = {y}, where x = {x}, a = {a}");
            }); 
        }
    }
}
