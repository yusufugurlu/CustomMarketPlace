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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.UpdatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.DeletedDate).HasColumnType("timestamp without time zone");

            builder.HasData(
          new Role(){ Id = 1,Name = "Super Yönetici",NameEn = "Super Admin",CreatedDate = DateTime.Now,RoleType = Common.Enums.RoleType.SuperAdmin,},
          new Role(){Id = 2,Name = "Şirket Yönetici",NameEn = "Company Admin",CreatedDate = DateTime.Now,RoleType = Common.Enums.RoleType.CompanyAdmin,},
          new Role(){Id = 3,Name = "Şirket Kullanıcısı",NameEn = "Company User",CreatedDate = DateTime.Now,RoleType = Common.Enums.RoleType.CompanyUser,},
          new Role() { Id = 4, Name = "Demo Kullanıcısı", NameEn = "Demo User", CreatedDate = DateTime.Now, RoleType = Common.Enums.RoleType.DemoUser, }
     );
        }
    }
}
