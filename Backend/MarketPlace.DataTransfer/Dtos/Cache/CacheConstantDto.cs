using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Cache
{
    public class CacheConstantDto
    {
        public string Key { get; set; }
        public string Definition { get; set; }
        public bool IsGlobal { get; set; }
    }
}
