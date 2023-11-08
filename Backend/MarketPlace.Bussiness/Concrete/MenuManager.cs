using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.Helper;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Breadcrumb;
using MarketPlace.DataTransfer.Dtos.Menus;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MarketPlace.Bussiness.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IGenericRepository<RoleMenu> _roleMenuRepository;
        private readonly IRedisService _redisService;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        public MenuManager(IUnitOfWorks unitOfWorks, IRedisService redisService)
        {
            _unitOfWorks = unitOfWorks;
            _menuRepository = _unitOfWorks.GetGenericRepository<Menu>();
            _roleMenuRepository = _unitOfWorks.GetGenericRepository<RoleMenu>();
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _redisService = redisService;
            _roleRepository = _unitOfWorks.GetGenericRepository<Role>();

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

        public async Task<ServiceResult> GetMenus(string lang, int userId)
        {
            var menuDtos = new List<MenuDto>();

            var user = await _userRepository.Get(userId);
            var role = await _roleRepository.Get(user.RoleId);
            //Eğer süper adminse bütün sayfaları görebilecek.
            bool doesHasSuperAdmin = role.RoleType == Common.Enums.RoleType.SuperAdmin;

            var roleMenus = await _roleMenuRepository.GetAllToList(x => !x.IsDeleted && x.RoleId == user.RoleId);
            List<Menu> menus = (await GetMenusFromCacheOrDatabase()).Where(x => doesHasSuperAdmin || roleMenus.Select(y => y.MenuId).AsEnumerable().Contains(x.Id)).ToList();

            if (menus.Count > 0)
            {

                var parentMenus = menus.Where(x => x.ParentId == 0).ToList();
                foreach (var parentMenu in parentMenus)
                {
                    var menuDto = new MenuDto()
                    {
                        Icon = parentMenu.Icon,
                        Name = parentMenu.Name.GetMessageResourceKey(lang),
                        Path = parentMenu.Path,
                        UIName = parentMenu.UIName,
                        IsHide = parentMenu.IsHide,
                        SubMenus = GetSubMenusByParentId(parentMenu.Id, menus, lang)
                    };

                    menuDtos.Add(menuDto);
                }
            }

            return Result.Success(data: menuDtos, status: 200);
        }


        public List<MenuDto> GetSubMenusByParentId(int parentId, List<Menu> menus, string lang)
        {
            var menuDtos = new List<MenuDto>();

            var menuParent = menus.FirstOrDefault(x => x.Id == parentId);
            foreach (Menu menu in menus.Where(x => x.ParentId == parentId))
            {
                MenuDto menuDto = new MenuDto
                {
                    Icon = menu.Icon,
                    Name = menu.Name.GetMessageResourceKey(lang),
                    Path = menu.Path,
                    UIName = menu.UIName,
                    IsHide = menu.IsHide,
                    ParentName = menuParent.Name.GetMessageResourceKey(lang),
                    ParentUrl = menuParent.Path,
                    SubMenus = GetSubMenusByParentId(menu.Id, menus, lang) // Recursively get submenus
                };

                menuDtos.Add(menuDto);
            }

            return menuDtos;
        }

        public async Task<ServiceResult> GetBreadcrumbs(string path, string lang)
        {
            List<BreadcrumbDto> breadcrumbDtos = new List<BreadcrumbDto>();
            var menus = await GetMenusFromCacheOrDatabase();
            if (menus.Count > 0)
            {
                var selectedMenu = menus.FirstOrDefault(x => x.UIName == path);
                if (selectedMenu != null)
                {
                    int parentId = selectedMenu.ParentId;
                    breadcrumbDtos.Add(new BreadcrumbDto()
                    {
                        To = selectedMenu.UIName,
                        Text = selectedMenu.Name.GetMessageResourceValue(lang),
                    });

                    do
                    {
                        var parentMenu = menus.FirstOrDefault(x => x.Id == parentId);
                        parentId = parentMenu?.ParentId ?? 0;
                        if (parentMenu != null)
                        {
                            breadcrumbDtos.Add(new BreadcrumbDto()
                            {
                                To = parentMenu.UIName,
                                Text = parentMenu.Name.GetMessageResourceValue(lang),
                            });
                        }

                    }
                    while (parentId > 0);
                }
            }
            breadcrumbDtos.Reverse();
            return Result.Success("", 200, data: breadcrumbDtos);
        }
    }
}
