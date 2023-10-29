using MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceConfiguration;
using MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceLogConfiguration;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DataAccess.Contexts
{
    public class ApplicationLogDbContext : DbContext
    {
        public ApplicationLogDbContext(DbContextOptions<ApplicationLogDbContext> options)
: base(options)
        {
        }

        
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<UserPasswordHistory> UserPasswordHistories { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<DataBaseLogEntry> DataBaseLogEntries { get; set; }
        public DbSet<UserAuthorizedLog> UserAuthorizedLogs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ErrorLogConfiguration());
            modelBuilder.ApplyConfiguration(new DataBaseLogEntryConfiguration());
            modelBuilder.ApplyConfiguration(new UserAuthorizedLogConfiguration());
            modelBuilder.ApplyConfiguration(new LogEntryConfiguration());

        }

    }
}
