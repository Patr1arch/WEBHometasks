using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebHometask3._7.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send(HttpContext context)
        {
            if (context.Session.Keys.Contains("text"))  
            {
                return context.Session.GetString("text");
            }
            else
            {
                context.Session.SetString("text", "abacaba");
                return "text empty";
            }
        }
    }
}
