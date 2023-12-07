using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Attributes
{
    public class TrendyolAttributeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<TrendyolCategoryAttribute> CategoryAttributes { get; set; }
    }
}
