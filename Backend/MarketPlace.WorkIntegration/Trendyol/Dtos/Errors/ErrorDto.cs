using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Errors
{
    public class ErrorDto
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public List<object> Args { get; set; }
    }
}
