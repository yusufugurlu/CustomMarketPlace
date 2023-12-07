using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Integrations
{
    public class IntegrationSignInDto
    {
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string CustomKey { get; set; }
    }
}
