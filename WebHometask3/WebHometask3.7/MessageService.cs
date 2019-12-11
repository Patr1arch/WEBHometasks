using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHometask3._7.Services;
using Microsoft.AspNetCore.Http;

namespace WebHometask3._7
{
    public class MessageService
    {
        IMessageSender _sender;

        public MessageService(IMessageSender sender) 
        {
            _sender = sender;
        }

        public string Send(HttpContext context)
        {
            return _sender.Send(context);
        }
    }
}
