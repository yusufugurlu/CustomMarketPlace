using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Products
{
    public class CreateTrendyolRequestDto
    {
        public List<CreateTrendyolProductDto> Items { get; set; }
    }
}
