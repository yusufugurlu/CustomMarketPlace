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
    new Menu() { Id = 1, Name = "SystemManagement", CreatedDate = DateTime.Now, Icon = "tool", OrderNumber = 1, Path = "/", ParentId = 0, UIName = "systemManagement", },
    new Menu() { Id = 2, Name = "Settings", CreatedDate = DateTime.Now, Icon = "", OrderNumber = 1, Path = "/settings", ParentId = 1, UIName = "settings", },
    new Menu() { Id = 3, Name = "AdminWorkplaces", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/adminWorkplaces", ParentId = 2, UIName = "adminWorkplaces", IsHide = true, IsDeleted = false, },
      new Menu() { Id = 4, Name = "AdminCompanies", CreatedDate = DateTime.Now, Icon = "user", OrderNumber = 2, Path = "/adminCompanies", ParentId = 2, UIName = "adminCompanies", IsHide = true, IsDeleted = false, }
    );
        }
    }
}
