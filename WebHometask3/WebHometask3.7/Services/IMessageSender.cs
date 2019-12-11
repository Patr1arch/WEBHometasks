using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebHometask3._7.Services
{
    public interface IMessageSender
    {
        string Send(HttpContext context);
    }
}
