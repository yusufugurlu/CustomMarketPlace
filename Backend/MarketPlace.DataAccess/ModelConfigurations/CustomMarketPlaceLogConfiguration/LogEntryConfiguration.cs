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
    public class LogEntryConfiguration : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.Property(x => x.Timestamp).HasColumnType("timestamp without time zone");
        }
    }
}
