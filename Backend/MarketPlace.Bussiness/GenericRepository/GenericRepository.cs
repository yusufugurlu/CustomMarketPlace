using MarketPlace.Common.HttpContent;
using MarketPlace.DataAccess;
using MarketPlace.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            if (entity != null)
            {
                if (entity is BaseModel baseEntity)
                {
                    baseEntity.CreatedDate = DateTime.Now;
                    baseEntity.CreatedUserId = CurrentUser.UserId();

                    _dbSet.Update(entity);
                }
                else
                {
                    // if not baseEntity is remove
                    _dbSet.Remove(entity);
                }
            }
        }

        public async Task AddRange(List<T> entites)
        {
            foreach (var entity in entites)
            {
                if (entity != null)
                {
                    if (entity is BaseModel baseEntity)
                    {
                        baseEntity.CreatedDate = DateTime.Now;
                        baseEntity.CreatedUserId = CurrentUser.UserId();
                        _dbSet.Update(entity);
                    }
                    else
                    {
                        // if not baseEntity is remove
                        _dbSet.Remove(entity);
                    }
                }
            }
        }

        public async Task Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                if (entity is BaseModel baseEntity)
                {
                    baseEntity.DeletedUserId = CurrentUser.UserId();
                    baseEntity.IsDeleted = true;
                    baseEntity.DeletedDate= DateTime.Now;
                    _dbSet.Update(entity);
                }
                else
                {
                    // if not baseEntity is remove
                    _dbSet.Remove(entity);
                }
            }
        }

        public async Task Delete(T entity)
        {
            if (entity != null)
            {
                if (entity is BaseModel baseEntity)
                {
                    baseEntity.IsDeleted = true;
                    baseEntity.DeletedDate = DateTime.Now;
                    baseEntity.DeletedUserId = CurrentUser.UserId();
                    _dbSet.Update(entity);
                }
                else
                {
                    // if not baseEntity is remove
                    _dbSet.Remove(entity);
                }
            }
        }

        public async Task DeleteRange(List<T> entites)
        {
            foreach (var entity in entites)
            {
                if (entity != null)
                {
                    if (entity is BaseModel baseEntity)
                    {
                        baseEntity.IsDeleted = true;
                        baseEntity.DeletedDate = DateTime.Now;
                        baseEntity.DeletedUserId = CurrentUser.UserId();
                        _dbSet.Update(entity);
                    }
                    else
                    {
                        // if not baseEntity is remove
                        _dbSet.Remove(entity);
                    }
                }
            }
        }

        public async Task<T> Get(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking().FirstOrDefault();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _dbSet;
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public async Task<ApplicationDbContext> GetQueryDbContext()
        {
            return _context;
        }

        public async Task<IQueryable<T>> GetTake(Expression<Func<T, bool>> expression, int count)
        {
           return _dbSet.Where(expression).AsNoTracking().Take(count);
        }

        public async Task Update(T entity)
        {
            if (entity is BaseModel baseEntity)
            {
                baseEntity.UpdatedUserId = CurrentUser.UserId();
                baseEntity.UpdatedDate = DateTime.Now;
            }
             _dbSet.Update(entity);
        }

        public async Task UpdateRange(List<T> entites)
        {
            if (entites != null)
            {
                foreach (T entity in entites)
                {
                    if (entity is BaseModel baseEntity)
                    {
                        baseEntity.UpdatedUserId = CurrentUser.UserId();
                        baseEntity.UpdatedDate = DateTime.Now;
                        _dbSet.Update(entity);
                    }
                    else
                    {
                        // if not baseEntity is remove
                        _dbSet.Remove(entity);
                    }
                }

            }
        }
    }
}
