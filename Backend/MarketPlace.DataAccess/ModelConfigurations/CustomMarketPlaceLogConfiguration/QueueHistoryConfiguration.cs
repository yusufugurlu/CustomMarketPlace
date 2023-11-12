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
    internal class QueueHistoryConfiguration : IEntityTypeConfiguration<QueueHistory>
    {
        public void Configure(EntityTypeBuilder<QueueHistory> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
        }
    }
}
