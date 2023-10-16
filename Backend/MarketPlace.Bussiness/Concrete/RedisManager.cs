using MarketPlace.Bussiness.Abstract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class RedisManager : IRedisService
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IConfiguration _config;

        public RedisManager(IConfiguration config)
        {
            _config = config;
            _redis = ConnectionMultiplexer.Connect(_config["Redis:DebugConnection"].ToString());
        }

        public IDatabase GetDatabase()
        {
            return _redis.GetDatabase();
        }
        public async Task SetData<T>(string key, T value)
        {
            var database = GetDatabase();
            string data = JsonConvert.SerializeObject(value);
            database.StringSet(key, data);
        }

        public async Task<T> GetData<T>(string key)
        {
            var database = GetDatabase();
            string stringData = await database.StringGetAsync(key); ;
            return JsonConvert.DeserializeObject<T>(stringData);
        }

        public async Task<List<T>> GetDatas<T>(string key)
        {
            var database = GetDatabase();
            string stringData = await database.StringGetAsync(key); ;
            return JsonConvert.DeserializeObject<List<T>>(stringData);
        }

        public async Task<bool> DeleteData(string key)
        {
            var database = GetDatabase();
            return database.KeyDelete(key);
        }

        public async Task<bool> ExistKey(string key)
        {
            var database = GetDatabase();

            try
            {
                return await database.KeyExistsAsync(key);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
