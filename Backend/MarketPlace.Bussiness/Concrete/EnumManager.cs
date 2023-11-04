using MarketPlace.Bussiness.Abstract;
using MarketPlace.Common.Enums;
using MarketPlace.Common.Helper;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Dtos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class EnumManager : IEnumService
    {
        public async Task<List<EnumBaseDto>> GetGenders()
        {
            var lang = CurrentUser.GetCulture();
            return EnumHelper.GetAllEnumBaseDtos<Gender>(lang);
        }

        public async Task<List<EnumBaseDto>> GetIntegrationType()
        {
            var lang = CurrentUser.GetCulture();
            return EnumHelper.GetAllEnumBaseDtos<IntegrationType>(lang);
        }

        public async Task<List<EnumBaseDto>> GetRoles()
        {
            var lang = CurrentUser.GetCulture();
            return EnumHelper.GetAllEnumBaseDtos<RoleType>(lang);
        }
    }
}
