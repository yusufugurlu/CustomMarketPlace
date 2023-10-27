using MarketPlace.Bussiness.Concrete;
using MarketPlace.Common.Helper;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Dtos.SelectedUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Helper
{
    public static class SelectedCompany
    {

        public static int SelectedCompanyId
        {
            get
            {
                var cache = new RedisManager();
                var hasValue = cache.ExistKey(CacheConstant.SelectedCompany).Result;
                if (hasValue)
                {
                    var datas = cache.GetDatas<SelectedWorkplaceDto>(CacheConstant.SelectedCompany).Result;
                    var data = datas.FirstOrDefault(x => x.UserId == CurrentUser.UserId());

                    return data?.CompanyId ?? 0;
                }

                return 0;
            }
        }

        public static int SelectedWorkplaceId
        {
            get
            {
                var cache = new RedisManager();
                var hasValue = cache.ExistKey(CacheConstant.SelectedCompany).Result;
                if (hasValue)
                {
                    var datas = cache.GetDatas<SelectedWorkplaceDto>(CacheConstant.SelectedCompany).Result;
                    var data = datas.FirstOrDefault(x => x.UserId == CurrentUser.UserId());

                    return data?.WorkplaceId ?? 0;
                }

                return 0;
            }
        }
    }
}
