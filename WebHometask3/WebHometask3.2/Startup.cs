using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebHometask3._2
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

            int x = 5;
            int m = 2;
            int n = 4;
            double z = 0.0;
            app.Use(async (context, next) =>
            {
                z = ((Math.Pow(1 + m * x, n) - Math.Pow(1 + n * x, m)) / Math.Pow(x, 2));
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"((1 + m * x) ^ n - (1 + n * x) ^ m) / (x ^ 2) = {z}, where x = {x}, m = {m}, n = {n}");
            });          
        }
    }
}
