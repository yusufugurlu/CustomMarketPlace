using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Integrations
{
    public class TrendyolAttributeRequestDto: IntegrationSignInDto
    {
        public int CategoryId { get; set; }
    }
}
