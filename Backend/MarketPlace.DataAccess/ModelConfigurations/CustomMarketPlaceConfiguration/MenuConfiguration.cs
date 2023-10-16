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
    new Menu()
    {
        Id = 1,
        Name = "SystemManagement",
        CompanentKey = "SystemManagement",
        CreatedDate = DateTime.Now,
        Icon = "tool",
        OrderNumber = 1,
        Path = "/",
        ParentId = 0,
        UIName= "systemManagement",
    },
            new Menu()
            {
                Id = 2,
                Name = "CreateCompany",
                CompanentKey = "CreateCompany",
                CreatedDate = DateTime.Now,
                Icon = "shop",
                OrderNumber = 1,
                Path = "/createCompany",
                ParentId = 1,
                UIName = "createCompany",
            },
        new Menu()
        {
            Id = 3,
            Name = "CreateUser",
            CompanentKey = "CreateUser",
            CreatedDate = DateTime.Now,
            Icon = "user",
            OrderNumber = 2,
            Path = "/createUser",
            ParentId = 1,
            UIName = "createUser",
        }
    );
        }
    }
}
