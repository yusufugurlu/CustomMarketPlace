using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.UnitOfWorks
{
    public class UnitOfWorksLog : IUnitOfWorksLog
    {
        private readonly ApplicationLogDbContext _context;
        public UnitOfWorksLog(ApplicationLogDbContext context)
        {
            _context = context;
        }
        public IGenericLogRepository<T> GetGenericLogRepository<T>() where T : class, new()
        {
            return new GenericLogRepository<T>(_context);
        }

        public async Task<ServiceResult> SaveChanges()
        {
            var transaction = _context.Database.CurrentTransaction;
            if (transaction == null)
            {
                transaction = _context.Database.BeginTransaction();
            }
            try
            {
                var affected = _context.SaveChangesAsync().GetAwaiter().GetResult();
                transaction.Commit();
                return Result.Success("İşlem başarılı", 200, 200, affected);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                transaction.Dispose();
                _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList().ForEach(e => e.State = EntityState.Unchanged);
                return Result.Fail("İşlem sırasında hata oluştu", 500, 500, null);
            }
        }
    }
}
