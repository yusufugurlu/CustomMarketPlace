using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceConfiguration
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {

            builder.HasData(
new District()
{
    Id = 1,
    Name = "Adanaİlçesi",
    CityId = 1
}
);
        }
    }
}
