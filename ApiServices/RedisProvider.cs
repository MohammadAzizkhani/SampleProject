using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ApiServices
{
    public class RedisProvider
    {
        private async Task<IDatabase> ConnectToRedisAsync()
        {
            var connection = await ConnectionMultiplexer.ConnectAsync("localhost");
            return connection.GetDatabase();
        }

        public async Task SetToRedisAsync(string key, string value, TimeSpan? expireTime = null)
        {
            (await ConnectToRedisAsync()).StringSet(key, value, expireTime);
        }

        public async Task<int> GetFromRedisAsync(string key)
        {
            var value = await (await ConnectToRedisAsync()).StringGetAsync(key);
            return value.HasValue?Convert.ToInt32(value):0;
        }
    }
}
