using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceLogConfiguration
{
    internal class UserAuthorizedLogConfiguration : IEntityTypeConfiguration<UserAuthorizedLog>
    {
        public void Configure(EntityTypeBuilder<UserAuthorizedLog> builder)
        {
            builder.Property(x => x.LogDate).HasColumnType("timestamp without time zone");
        }
    }
}
