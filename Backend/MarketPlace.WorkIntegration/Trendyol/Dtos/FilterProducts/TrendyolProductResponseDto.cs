using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.FilterProducts
{
    public class TrendyolProductResponseDto
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public List<TrendyolProductContentDto> Content { get; set; }
    }
}
