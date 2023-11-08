using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.SystemParameter
{
    public class SystemParameterDto
    {
        public string? SmtpHost { get; set; }
        public string? SmtpUserName { get; set; }
        public string? SmtpPassword { get; set; }
        public int SmtpPort { get; set; }
        public int MaximumWorkplaceNumber { get; set; }
        public int MaximumUserNumber { get; set; }
    }
}
