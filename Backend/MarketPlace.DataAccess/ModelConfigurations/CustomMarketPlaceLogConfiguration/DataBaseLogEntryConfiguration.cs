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
    internal class DataBaseLogEntryConfiguration : IEntityTypeConfiguration<DataBaseLogEntry>
    {
        public void Configure(EntityTypeBuilder<DataBaseLogEntry> builder)
        {
            builder.Property(x => x.Timestamp).HasColumnType("timestamp without time zone");
        }
    }
}
