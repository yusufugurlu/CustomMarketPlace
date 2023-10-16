using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Errors
{
    public class ErrorLogDto
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public string Level { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
