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
            new RoleMenu(){ Id = 1, RoleId = 1,MenuId = 1,CreatedDate = DateTime.Now,},
            new RoleMenu(){Id = 2, RoleId = 1,MenuId = 2,CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 3, RoleId = 1, MenuId = 3, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 4, RoleId = 1, MenuId = 4, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 5, RoleId = 1, MenuId = 5, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 6, RoleId = 1, MenuId = 6, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 7, RoleId = 1, MenuId = 7, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 8, RoleId = 1, MenuId = 8, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 9, RoleId = 1, MenuId = 9, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 10, RoleId = 2, MenuId = 8, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 11, RoleId = 2, MenuId = 9, CreatedDate = DateTime.Now, },
            new RoleMenu() { Id = 12, RoleId = 2, MenuId = 12, CreatedDate = DateTime.Now, },
             new RoleMenu() { Id = 13, RoleId = 2, MenuId = 13, CreatedDate = DateTime.Now, }
            );
        }
    }
}
