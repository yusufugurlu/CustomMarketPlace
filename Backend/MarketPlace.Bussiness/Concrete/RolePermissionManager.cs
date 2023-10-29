using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.RolePermission;
using MarketPlace.DataTransfer.Dtos.Workplace;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICompanyService _companyService;
        private readonly IWorkplaceService _workplaceService;
        public RolePermissionManager(IUnitOfWorks unitOfWorks,
            IMenuService menuService, 
            ICompanyService companyService,
            IWorkplaceService workplaceService)
        {

            _unitOfWorks = unitOfWorks;
            _menuService = menuService;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _roleMenuRepository = _unitOfWorks.GetGenericRepository<RoleMenu>();
            _companyService = companyService;
            _workplaceService = workplaceService;
        }

        public async Task<List<RoleCompanyDto>> GetCompanyByUserId(int userId)
        {
            var user = (await _userRepository.GetAll(x => x.Id == userId)).Include(x => x.Role).AsNoTracking().FirstOrDefault();
            if (user != null && user.Role.RoleType == RoleType.SuperAdmin)
            {
                var companies = (List<CompanyDto>)(await _companyService.GetActiveCompanies()).Data;

                return companies.Select(x => new RoleCompanyDto()
                {
                    Id = x.Id,
                    CompanyName = x.Name
                })
                    .OrderBy(x=>x.CompanyName)
                    .ToList();

            }
            return new List<RoleCompanyDto>();
        }

        public async Task<List<RoleWorkplaceDto>> GetWorkplacesByCompanyId(int companyId, int userId)
        {
            var user = (await _userRepository.GetAll(x => x.Id == userId)).AsNoTracking().FirstOrDefault();
            if (user != null)
            {
                var workplaces = (List<WorkplaceDto>)(await _workplaceService.GetActiveWorkPlaces(companyId)).Data;

                if (workplaces.Any())
                {
                    return workplaces.Select(x => new RoleWorkplaceDto()
                    {
                        Id = x.Id,
                        WorkplaceName = x.Name
                    })
                        .OrderBy(x => x.WorkplaceName)
                        .ToList();
                }
            }
            return new List<RoleWorkplaceDto>();
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
