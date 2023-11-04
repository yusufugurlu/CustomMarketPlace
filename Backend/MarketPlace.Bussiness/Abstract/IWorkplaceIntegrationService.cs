using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.WorkplaceIntegration;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IWorkplaceIntegrationService
    {
        Task<ServiceResult> GetIntegrations(int workplaceId);
        Task<ServiceResult> CreateIntegration(CreateWorkplaceIntegrationDto dto, string lang);
        Task<ServiceResult> GetIntegration(int integrationId, string lang);
        Task<ServiceResult> DeleteIntegration(DeleteWorkplaceIntegrationDto integrationDto, string lang);
    }
}
