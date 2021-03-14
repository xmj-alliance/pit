using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisWebAPI.App.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecord<T>(
            this IDistributedCache cache,
            string recordID,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null
        )
        {
            var options = new DistributedCacheEntryOptions() {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = unusedExpireTime,
            };

            string dataInJSON = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordID, dataInJSON, options);
        }

        public static async Task<T> GetRecord<T>(this IDistributedCache cache, string recordID)
        {
            string dataInJSON = await cache.GetStringAsync(recordID);

            return (dataInJSON is null?
                        default(T):
                        JsonSerializer.Deserialize<T>(dataInJSON));
        }
    }
}