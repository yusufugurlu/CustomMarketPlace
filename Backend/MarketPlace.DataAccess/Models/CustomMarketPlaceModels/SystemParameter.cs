using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    public class SystemParameter : BaseModel
    {
        public string? SmtpHost { get; set; }
        public string? SmtpUserName { get; set; }
        public string? SmtpPassword { get; set; }
        public int SmtpPort { get; set; }
        public int MaximumWorkplaceNumber { get; set; }
        public int MaximumWUserNumber { get; set; }
    }
}
