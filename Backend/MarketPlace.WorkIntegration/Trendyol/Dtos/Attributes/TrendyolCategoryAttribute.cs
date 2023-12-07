using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Attributes
{
    public class TrendyolCategoryAttribute
    {
        public bool AllowCustom { get; set; }
        public TrendyolAttribute Attribute { get; set; }
        public List<TrendyolAttributeValue> AttributeValues { get; set; }
        public int CategoryId { get; set; }
        public bool Required { get; set; }
        public bool Varianter { get; set; }
        public bool Slicer { get; set; }
    }
}
