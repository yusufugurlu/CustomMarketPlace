using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IWorkplaceService
    {
        Task<ServiceResult> GetActiveWorkPlaces(int companyId);
        Task<ServiceResult> CreateWorkPlace(WorkplaceDto dto);
        Task<ServiceResult> GetWorkPlace(int workplaceId);
        Task<ServiceResult> DeleteWorkPlace(DeleteWorkplaceDto dto);
    }
}
