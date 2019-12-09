using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebHometask3._5
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await _next.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response.WriteAsync("Access Denied");
            }
            if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("Page not found");
            }
        }
    }

    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public List<string> autList;
        public AuthenticationMiddleware(RequestDelegate next, List<string> aL)
        {
            _next = next;
            autList = aL;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (autList.Contains(token)) {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 403;
            }
        }
    }

    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/time")
            {
                await context.Response.WriteAsync(DateTime.Now.ToString());
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
