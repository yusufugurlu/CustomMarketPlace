using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Common.Helper
{
    public static class CacheConstant
    {
        public readonly static string MenuCache = "MarketPlace.Menus";
        public readonly static string SelectedCompany = "MarketPlace.SelectedCompany";
        public static string RedisConnection { get; set; } = "";
    }
}
