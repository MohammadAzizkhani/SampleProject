using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Configuration;
using ApiServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Api.Middlewares
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RedisProvider _redisProvider;
        private readonly RateLimitConfiguration _limitConfig;

        public RateLimitMiddleware(RequestDelegate next,RedisProvider redisProvider,IOptions<RateLimitConfiguration> limitConfig)
        {
            _limitConfig = limitConfig.Value;
            _next = next;
            _redisProvider = redisProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress.ToString();
            var count = await _redisProvider.GetFromRedisAsync(ip);
            if (count > _limitConfig.LimitationCount)
            {
                context.Response.StatusCode = 429;
                await context.Response.WriteAsync("429");
            }
            count++;
            await _redisProvider.SetToRedisAsync(ip, count.ToString(), TimeSpan.MaxValue);
            await _next(context);
        }
    }
}
