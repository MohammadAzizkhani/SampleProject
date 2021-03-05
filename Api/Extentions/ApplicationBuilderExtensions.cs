using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Api
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerExtention(this IApplicationBuilder builder)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Api v1");
            });
        }
    }
}
