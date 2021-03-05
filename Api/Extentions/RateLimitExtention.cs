using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Api.Extentions
{
    public static class RateLimitExtention
    {
        public static IApplicationBuilder UseRequesFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RateLimitMiddleware>();
        }
    }
}
