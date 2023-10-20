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
    internal class RoleMenuConfiguration : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.UpdatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.DeletedDate).HasColumnType("timestamp without time zone");

            builder.HasData(
                new RoleMenu()
                {
                    Id = 1,
                    RoleId = 1,
                    MenuId = 1,
                    CreatedDate = DateTime.Now,
                },
                new RoleMenu()
                {
                    Id = 2,
                    RoleId = 1,
                    MenuId = 2,
                    CreatedDate = DateTime.Now,
                }
                );
        }
    }
}
