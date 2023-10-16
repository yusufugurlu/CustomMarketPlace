using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IRedisService
    {
        IDatabase GetDatabase();
        Task SetData<T>(string key, T value);
        Task<T> GetData<T>(string key);
        Task<List<T>> GetDatas<T>(string key);
        Task<bool> DeleteData(string key);
        Task<bool> ExistKey(string key);
    }
}
