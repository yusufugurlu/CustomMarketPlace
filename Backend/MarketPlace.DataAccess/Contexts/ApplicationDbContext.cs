using MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceConfiguration;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationLogDbContext _logDbContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ApplicationLogDbContext logDbContext)
    : base(options)
        {
            _logDbContext = logDbContext;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<IntegrationForWorkPlace> IntegrationForWorkPlaces { get; set; }
        public DbSet<UserPasswordRecovery> UserPasswordRecoveries { get; set; }
        public DbSet<SystemParameter> SystemParameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            //modelBuilder.ApplyConfiguration(new CityConfiguration());
            //modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new RoleMenuConfiguration());
            modelBuilder.ApplyConfiguration(new WorkplaceConfiguration());
            modelBuilder.ApplyConfiguration(new UserPasswordRecoveryConfiguration());
            modelBuilder.ApplyConfiguration(new IntegrationForWorkPlaceConfiguration());
            modelBuilder.ApplyConfiguration(new SystemParameterConfiguration());

        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var changes = ChangeTracker.Entries()
    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
    .Select(e => new
    {
        EntityName = e.Entity.GetType().Name,
        EntityId = e.OriginalValues["Id"] ?? e.CurrentValues["Id"],
        Action = e.State,
        Changes = JsonConvert.SerializeObject(e.State == EntityState.Deleted ? e.OriginalValues.Properties.ToDictionary(p => p.Name, p => e.OriginalValues[p]) : e.OriginalValues.Properties.ToDictionary(p => p.Name, p => e.CurrentValues[p]))
    });

            foreach (var change in changes)
            {
                _logDbContext.LogEntries.Add(new LogEntry
                {
                    Timestamp = DateTime.Now,
                    Action = change.Action.ToString(),
                    Entity = change.EntityName,
                    EntityId = change.EntityId.ToString(),
                    Changes = change.Changes
                });
            }

             _logDbContext.SaveChanges();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
