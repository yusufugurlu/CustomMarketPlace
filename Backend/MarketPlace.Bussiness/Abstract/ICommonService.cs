using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface ICommonService
    {
        Task<ServiceResult> SetSelectCompany(int userId, int companyId);
        Task<ServiceResult> SetSelectWorkplace(int userId, int companyId, int workplaceId);
    }
}
