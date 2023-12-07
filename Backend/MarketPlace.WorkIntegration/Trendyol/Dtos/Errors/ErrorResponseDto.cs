using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Errors
{
    public class ErrorResponseDto
    {
        public long Timestamp { get; set; }
        public string Exception { get; set; }
        public List<ErrorDto> Errors { get; set; }
    }
}
