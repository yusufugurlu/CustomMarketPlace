using MarketPlace.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.GenericRepository
{
    public interface IGenericLogRepository<T> where T : class, new()
    {
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<T> Get(int id);
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetTake(Expression<Func<T, bool>> expression, int count);
        Task Delete(int id);
        Task Delete(T entity);
        Task DeleteRange(List<T> entites);
        Task Update(T entity);
        Task UpdateRange(List<T> entites);
        Task Add(T entity);
        Task AddRange(List<T> entites);
        Task<ApplicationLogDbContext> GetQueryDbContext();
    }
}
