using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.Helper;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Menus;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Bussiness.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IRedisService _redisService;
        public MenuManager(IUnitOfWorks unitOfWorks, IRedisService redisService)
        {
            _unitOfWorks = unitOfWorks;
            _menuRepository = _unitOfWorks.GetGenericRepository<Menu>();
            _redisService = redisService;

        }


        public async Task<List<Menu>> GetMenusFromCacheOrDatabase()
        {

            bool existInCache = await _redisService.ExistKey(CacheConstant.MenuCache);
            if (existInCache)
            {
                return await _redisService.GetDatas<Menu>(CacheConstant.MenuCache);
            }
            else
            {
                var menus = (await _menuRepository
                    .GetAll(x => !x.IsDeleted))
                    .AsNoTracking()
                    .ToList();

                await _redisService.SetData(CacheConstant.MenuCache, menus);
                return menus;
            }
        }

        public async Task<ServiceResult> GetMenus(string lang)
        {
            var menuDtos = new List<MenuDto>();
            List<Menu> menus = await GetMenusFromCacheOrDatabase();

            if (menus.Count > 0)
            {
                var parentMenus = menus.Where(x => x.ParentId == 0).ToList();
                var subMenus = menus.Where(x => x.ParentId > 0).ToList();
                foreach (var parentMenu in parentMenus)
                {
                    var menuDto = new MenuDto()
                    {
                        Icon = parentMenu.Icon,
                        Name = parentMenu.Name.GetMessageResourceKey(lang),
                        Path = parentMenu.Path,
                        UIName = parentMenu.UIName
                    };

                    menuDto.SubMenus = subMenus.Where(x => x.ParentId == parentMenu.Id).Select(x => new MenuDto
                    {
                        Icon = x.Icon,
                        Name = x.Name.GetMessageResourceKey(lang),
                        Path = x.Path,
                        UIName = x.UIName
                    }).ToList();
                    menuDtos.Add(menuDto);
                }
            }

            return Result.Success(data: menuDtos, status: 200);
        }
    }
}
