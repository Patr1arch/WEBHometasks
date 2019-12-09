using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebHometask3._4
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseToken("Demidovich");

            int x = 42;
            double y = 0;
            app.Use(async (context, next) =>
            {
                //var tmp1 = (Math.Pow(1 + Math.Pow(x, 4), 1 / 4) + x);
                //var tmp2 = (Math.Pow(1 + Math.Pow(x, 4), 1 / 4) - x);
                //y = Math.Round(1 / 4 * Math.Log( tmp1 / tmp2) - 1 / 2 * Math.Atan(Math.Pow(1 + Math.Pow(x, 4), 1 / 4) / x));
                y = Math.Round((3 - x) / (2) + Math.Sqrt(1 - 12 * x + x * x) + 2 * Math.Asin((1 + x) / Math.Sqrt(x*x + 120)));
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"(3 - x) / (2) + Sqrt(1 - 12 * x + x * x) + 2 * Asin((1 + x) / Sqrt(x*x + 120))) = {y}, where x = {x}");
                //await context.Response.WriteAsync($"1/4 * Log( (Pow( 1 + Pow(x, 4), 1/4 ) + x) / ( Pow(1 + Pow(x, 4) , 1 / 4) - x) ) - 1/2 * Atan( Pow(1 + Pow(x, 4), 1 / 4) / x) = {y}, where x = {x}");
            });
        }
    }
}
