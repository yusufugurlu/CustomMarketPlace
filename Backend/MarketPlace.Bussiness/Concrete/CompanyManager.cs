using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.HttpContent;
using MarketPlace.Common.Resources;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IGenericRepository<WorkPlace> _workplaceRepository;
        public CompanyManager(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _companyRepository = _unitOfWorks.GetGenericRepository<Company>();
            _workplaceRepository = _unitOfWorks.GetGenericRepository<WorkPlace>();

        }

        public async Task<ServiceResult> CreateCompany(CreateCompanyDto dto)
        {
            if (dto != null)
            {

                if (dto.Id == 0) //added
                {
                    var company = _mapper.Map<Company>(dto);
                    await _companyRepository.Add(company);
                }
                else //updated
                {
                    var company = await _companyRepository.Get(dto.Id);
                    company.Name = dto.Name;
                    company.ShortName = dto.ShortName;
                    company.IsActive= dto.IsActive;
                    await _companyRepository.Update(company);
                }

                return await _unitOfWorks.SaveChanges();
            }

            return Result.Fail("", 500);
        }

        public async Task<ServiceResult> DeleteCompany(DeleteCompanyDto companyDto, string lang)
        {
            var companies = (await _companyRepository.GetAll(x => !x.IsDeleted && companyDto.CompanyIds.Contains(x.Id))).ToList();
            var workplaces = (await _workplaceRepository.GetAll(x => !x.IsDeleted && companies.Select(c => c.Id).Contains(x.CompanyId))).ToList();
            StringBuilder validation = new StringBuilder();

            foreach (var company in companies)
            {
                if (company.Id == 1)
                {
                    validation.Append($"{company.Name} - {"CannotDeleteParentCompany".GetAlertResourceValue(lang)}\n");
                }

                if (workplaces.Any(x => x.CompanyId == company.Id))
                {
                    validation.Append($"{company.Name} - {"StoresAreAvailable".GetAlertResourceValue(lang)}\n");
                }
            }

            if (validation.Length > 0)
            {
                return Result.Fail(validation.ToString());
            }

            await _companyRepository.DeleteRange(companies);
            return await _unitOfWorks.SaveChanges();
        }

        public async Task<ServiceResult> EditCompany(int companyId)
        {
            var companies = ((await _companyRepository.Get(companyId)));
            var mapDto = _mapper.Map<CompanyDto>(companies);
            return Result.Success("", 200, 0, mapDto);
        }

        public async Task<ServiceResult> GetActiveCompanies()
        {
            var companies = ((await _companyRepository.GetAllWithOuthAsNoTracking(x => !x.IsDeleted && x.IsActive))).ToList();
            List<CompanyDto> mapDtos = _mapper.Map<List<CompanyDto>>(companies);
            return Result.Success("", 200, 0, mapDtos.OrderBy(x => x.Name).ToList());
        }

        public async Task<ServiceResult> GetCompanies()
        {
            var lang=CurrentUser.GetCulture();
            var companies = ((await _companyRepository.GetAllWithOuthAsNoTracking(x => !x.IsDeleted))).ToList();
            List<CompanyDto> mapDtos = _mapper.Map<List<CompanyDto>>(companies);
            mapDtos.ForEach((item) => { item.IsActiveByLang = item.IsActive.ToString().GetMessageResourceKey(lang); });
            return Result.Success("", 200, 0, mapDtos.OrderBy(x=>x.Name).ToList());
        }
    }
}
