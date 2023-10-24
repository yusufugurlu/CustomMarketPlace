using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface ICompanyService
    {
        Task<ServiceResult> GetActiveCompanies();
        Task<ServiceResult> CreateCompany(CompanyDto dto);
        Task<ServiceResult> EditCompany(int companyId);
        Task<ServiceResult> DeleteCompany(DeleteCompanyDto companyDto);
    }
}
