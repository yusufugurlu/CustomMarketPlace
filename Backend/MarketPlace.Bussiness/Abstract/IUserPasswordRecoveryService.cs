using MarketPlace.DataTransfer.Dtos.UserPasswordRecovery;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IUserPasswordRecoveryService
    {
        Task<ServiceResult> CreatePasswordRecovery(UserPasswordRecoveryDto dto);
        Task<ServiceResult> DeletePasswordRecoveriesByUserId(int userId);
        Task<ServiceResult> CheckGuid(string guidKey,string lang);
    }
}
