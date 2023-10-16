using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.DataTransfer.ServiceResults;

namespace MarketPlace.Bussiness.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWorks(ApplicationDbContext context, ILoggerService loggerService)
        {
            if (context != null)
                _context = context;

        }
        public IGenericRepository<T> GetGenericRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_context);
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
                return Result.Fail("İşlem sırasında hata oluştu", 500, 500, null);
            }
        }
    }
}
