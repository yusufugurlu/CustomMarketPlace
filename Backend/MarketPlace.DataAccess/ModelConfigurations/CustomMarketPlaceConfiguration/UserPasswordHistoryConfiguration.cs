using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
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
    public class UserPasswordHistoryConfiguration : IEntityTypeConfiguration<UserPasswordHistory>
    {
        public void Configure(EntityTypeBuilder<UserPasswordHistory> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.UpdatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.DeletedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.ExpiryDate).HasColumnType("timestamp without time zone");
        }
    }
}
