using MarketPlace.DataTransfer.Dtos.Account;
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
        Task<ServiceResult> GetUserInfo(int userId);
        Task<ServiceResult> ChangeLanguage(CustomLanguageDto dto, int userId);
        Task<ServiceResult> SetSelectCompany(int userId, int companyId);
    }
}
