using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Dtos.User;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IUserService
    {
        Task<ServiceResult> CreateUser(CreateUserDto dto, string lang);
        Task<ServiceResult> GetUserInfo(int userId);
        Task<ServiceResult> ChangeLanguage(CustomLanguageDto dto, int userId);
        Task<ServiceResult> GetUsersByCompanyId(int companyId, string lang);
        Task<ServiceResult> GetUser(int userId, string lang);
        Task<ServiceResult> UpdateUser(EditUserParameterDto dto, string lang);
        Task<ServiceResult> DeleteUsers(List<int> userIds, string lang);
        Task<ServiceResult> CreateUserForNormalRole(CreateUserDto dto, string lang);
    }
}
