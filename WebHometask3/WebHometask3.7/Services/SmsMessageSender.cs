using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebHometask3._7.Services
{
    public class SmsMessageSender : IMessageSender
    {
        public string Send(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("text"))
            {
                return context.Request.Cookies["text"];
            }
            else
            {
                context.Response.Cookies.Append("text", "abacaba");
                return "text empty";
            }
        }
    }
}
