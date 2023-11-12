using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceLogConfiguration
{
    public class CustomQueueConfiguration : IEntityTypeConfiguration<CustomQueue>
    {
        public void Configure(EntityTypeBuilder<CustomQueue> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
        }
    }
}
