using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace DynamicSettings
{
    public class RedisSettings : ISettings
    {
        private readonly IDatabase _redis;
        private const string RedisKey = "AppSettings";

        public RedisSettings(IDatabase redis)
        {
            _redis = redis;
        }

        public string Get(string key)
        {
            var val = _redis.HashGet(RedisKey, key);
            return val.ToString();
        }

        public IDictionary<string, string> GetAll()
        {
            var all = _redis.HashGetAll(RedisKey);
            return all.ToDictionary(x => x.Name.ToString(), x => x.Value.ToString());
        }
    }
}