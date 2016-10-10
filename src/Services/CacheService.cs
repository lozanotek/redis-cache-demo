using System.Configuration;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace RedisDemo.Services
{
    public static class CacheService
    {
        private static readonly ICacheClient cacheClient = CreateCacheClient();

        private static ICacheClient CreateCacheClient()
        {
            var connString = ConfigurationManager.ConnectionStrings["azure.Redis"];
            if (connString == null)
            {
                return null;
            }

            ISerializer serializer = new NewtonsoftSerializer();
            return new StackExchangeRedisCacheClient(serializer, connString.ConnectionString, 1000);
        }

        public static ICacheClient CacheClient => cacheClient;
    }
}