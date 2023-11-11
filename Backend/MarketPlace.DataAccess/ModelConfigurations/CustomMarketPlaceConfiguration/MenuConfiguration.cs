using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceConfiguration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.UpdatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.DeletedDate).HasColumnType("timestamp without time zone");


            builder.HasData(
    new Menu() { Id = 1, Name = "SystemManagement", CreatedDate = DateTime.Now, Icon = "tool", OrderNumber = 1, Path = "/systemManagement", ParentId = 0, UIName = "systemManagement", },
    new Menu() { Id = 2, Name = "Settings", CreatedDate = DateTime.Now, Icon = "", OrderNumber = 1, Path = "/settings", ParentId = 1, UIName = "settings", },
    new Menu() { Id = 3, Name = "AdminWorkplaces", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/adminWorkplaces", ParentId = 2, UIName = "adminWorkplaces", IsHide = true, IsDeleted = false, },
    new Menu() { Id = 4, Name = "AdminCompanies", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/adminCompanies", ParentId = 2, UIName = "adminCompanies", IsHide = true, IsDeleted = false, },
    new Menu() { Id = 5, Name = "AdminUsers", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/adminUsers", ParentId = 2, UIName = "adminUsers", IsHide = true, IsDeleted = false, },
    new Menu() { Id = 6, Name = "CacheManagment", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/cacheManagment", ParentId = 2, UIName = "cacheManagment", IsHide = true, IsDeleted = false, },
    new Menu() { Id = 7, Name = "IntegrationManagment", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/integrationManagment", ParentId = 2, UIName = "integrationManagment", IsHide = true, IsDeleted = false, },
    new Menu() { Id = 8, Name = "WorkplaceManagment", CreatedDate = DateTime.Now, Icon = "shop", OrderNumber = 2, Path = "/workplaceManagment", ParentId = 0, UIName = "WorkplaceManagment", IsHide = false, IsDeleted = false, },
    new Menu() { Id = 9, Name = "Integration", CreatedDate = DateTime.Now, Icon = "", OrderNumber = 2, Path = "/integration", ParentId = 8, UIName = "integration", IsHide = false, IsDeleted = false, },
    new Menu() { Id = 10, Name = "AdminAllWorkplaces", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/adminAllWorkplaces", ParentId = 2, UIName = "adminAllWorkplaces", IsHide = true, IsDeleted = false, },
     new Menu() { Id = 11, Name = "SystemParameter", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/systemParameter", ParentId = 2, UIName = "systemParameter", IsHide = true, IsDeleted = false, },
     new Menu() { Id = 12, Name = "Workplaces", CreatedDate = DateTime.Now, Icon = "", OrderNumber = 2, Path = "/workplaces", ParentId = 8, UIName = "workplaces", IsHide = false, IsDeleted = false, },
     new Menu() { Id = 13, Name = "Users", CreatedDate = DateTime.Now, Icon = "", OrderNumber = 2, Path = "/users", ParentId = 8, UIName = "users", IsHide = false, IsDeleted = false, }
    );
        }
    }
}
