using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class RolePermissionManager : IRolePermissionService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<RoleMenu> _roleMenuRepository;
        private readonly IMenuService _menuService;
        public RolePermissionManager(IUnitOfWorks unitOfWorks, IMenuService menuService)
        {

            _unitOfWorks = unitOfWorks;
            _menuService = menuService;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _roleMenuRepository = _unitOfWorks.GetGenericRepository<RoleMenu>();
        }
        public async Task<bool> HasPermissionInMenu(int userId, string menuName)
        {
            var user = await _userRepository.Get(userId);
            if (user != null)
            {
                var menus = await _menuService.GetMenusFromCacheOrDatabase();
                if (menus.Any(x => !x.IsDeleted && x.UIName == menuName))
                {
                    var menu = menus.FirstOrDefault(x => x.UIName == menuName);
                    if (menu != null)
                    {
                        var roleMenuList = await _roleMenuRepository.GetAll(x => !x.IsDeleted && x.RoleId == user.RoleId && x.MenuId == menu.Id);
                        return roleMenuList.Any();
                    }
                }
            }

            return false;
        }
    }
}
