using MarketPlace.DataTransfer.Dtos.RolePermission;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IRolePermissionService
    {
        Task<bool> HasPermissionInMenu(int userId,string menuName);
        Task<List<RoleCompanyDto>> GetCompanyByUserId(int userId);
    }
}
