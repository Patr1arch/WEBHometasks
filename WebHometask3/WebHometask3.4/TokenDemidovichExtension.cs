using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WebHometask3._4
{
    public static class TokenDemidovichExtension
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenDemidovichMiddleware>(pattern);
        }
    }
}
