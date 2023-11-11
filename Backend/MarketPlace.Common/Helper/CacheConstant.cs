using MarketPlace.DataTransfer.Dtos.Cache;
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
        public readonly static string SystemParameter = "MarketPlace.SystemParameter";
        public static string RedisConnection { get; set; } = "";

        public readonly static List<CacheConstantDto> listOfKeyDefinitions = new List<CacheConstantDto>()
        {
            new CacheConstantDto()
            {
                Key="MarketPlace.Menus",
                IsGlobal=true,
                Definition="Sistemde bulunan menüleri listeler"
            },
            new CacheConstantDto()
            {
                Key="MarketPlace.SelectedCompany",
                IsGlobal=false,
                Definition="Sistemi kullanan kişilerin seçili şirket ve iş yerlerinin id' lerin bilgilerini listeler."
            },
             new CacheConstantDto()
            {
                Key="MarketPlace.SystemParameter",
                IsGlobal=true,
                Definition="Sistem için genel bilgileri tutar (Örnek smtp bilgiler v.b.)"
            },
        };
    }
}
