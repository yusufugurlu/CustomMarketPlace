using MarketPlace.Common.Extentions;
using MarketPlace.DataTransfer.Dtos.Enum;
using MarketPlace.DataTransfer.Dtos.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Common.Helper
{
    public static class EnumHelper
    {
        public static List<EnumBaseDto> GetAllEnumBaseDtos<TEnum>(string lang) where TEnum : struct, Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enum type.");
            }

            List<EnumBaseDto> dtos = new List<EnumBaseDto>();
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            foreach (var value in enumValues)
            {
                dtos.Add(new EnumBaseDto((int)(object)value, value.ToString().GetResourceValue(lang)));
            }

            return dtos;
        }
    }

}

