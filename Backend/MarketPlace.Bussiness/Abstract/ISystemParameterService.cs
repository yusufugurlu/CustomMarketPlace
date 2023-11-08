using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.SystemParameter;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface ISystemParameterService
    {
        Task<ServiceResult> UpdateSystemParameter(SystemParameterDto parameter);
        Task<SystemParameterDto> GetSystemParameterFromCacheOrDatabase();
        Task<List<SystemParameterDto>> GetSystemParameters();
    }
}
