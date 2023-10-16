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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.UpdatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.DeletedDate).HasColumnType("timestamp without time zone");

            builder.HasData(
                new User()
                {
                    Id = 1,
                    Name = "Admin",
                    SurName = "Admin",
                    Email = "admin@admin.com",
                    Password = "Password1.",
                    RoleId = 1,
                    Gender = Common.Enums.Gender.Other,
                    CreatedDate = DateTime.Now,
                    CompanyId = 1,
                    Phone = "",
                    SelectedLanguage = Common.Enums.LanguageType.TR,
                }
                );
        }
    }
}
