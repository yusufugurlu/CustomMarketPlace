using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IMenuService
    {
        Task<ServiceResult> GetMenus(string lang);
        Task<List<Menu>> GetMenusFromCacheOrDatabase();
    }
}
