using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.Dtos.WorkplaceIntegration;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class WorkplaceIntegrationManager : IWorkplaceIntegrationService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IntegrationForWorkPlace> _integrationForWorkPlaceRepository;
        public WorkplaceIntegrationManager(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _integrationForWorkPlaceRepository = _unitOfWorks.GetGenericRepository<IntegrationForWorkPlace>();

        }
        public async Task<ServiceResult> CreateIntegration(CreateWorkplaceIntegrationDto dto, string lang)
        {
            if (dto != null && dto.WorkPlaceId != 0)
            {

                if (dto.Id == 0) //added
                {
                    var integrationForWorkPlace = _mapper.Map<IntegrationForWorkPlace>(dto);
                    integrationForWorkPlace.IntegrationType = (IntegrationType)dto.IntegrationType;
                    await _integrationForWorkPlaceRepository.Add(integrationForWorkPlace);
                }
                else //updated
                {
                    var integrationForWorkPlace = await _integrationForWorkPlaceRepository.Get(dto.Id);
                    integrationForWorkPlace.ApiSecret = dto.ApiSecret;
                    integrationForWorkPlace.ApiKey = dto.ApiKey;
                    integrationForWorkPlace.IdForApi = dto.IdForApi;
                    integrationForWorkPlace.WorkPlaceId= dto.WorkPlaceId;
                    await _integrationForWorkPlaceRepository.Update(integrationForWorkPlace);
                }

                return await _unitOfWorks.SaveChanges();
            }

            return Result.Fail("PleaseSelectShop".GetAlertResourceValue(lang), 500);
        }

        public async Task<ServiceResult> DeleteIntegration(DeleteWorkplaceIntegrationDto integrationDto, string lang)
        {
            var integrationForWorkPlaces = (await _integrationForWorkPlaceRepository.GetAll(x => !x.IsDeleted && integrationDto.WorkplaceIntegrationIds.Contains(x.Id))).ToList();
            await _integrationForWorkPlaceRepository.DeleteRange(integrationForWorkPlaces);
            return await _unitOfWorks.SaveChanges();
        }

        public async Task<ServiceResult> GetIntegration(int integrationId, string lang)
        {
            var integrationForWorkPlace = (await _integrationForWorkPlaceRepository.Get(integrationId));
            var mapDto = _mapper.Map<WorkplaceIntegrationViewDto>(integrationForWorkPlace);
            mapDto.IntegrationTypeName = ((IntegrationType)mapDto.IntegrationType).ToString().GetMessageResourceKey(lang);
            return Result.Success("", 200, 0, mapDto);
        }

        public async Task<ServiceResult> GetIntegrations(int workplaceId)
        {
            string lang = CurrentUser.GetCulture();
            var integrationForWorkPlaces = await _integrationForWorkPlaceRepository.GetAllToList(x => !x.IsDeleted && x.WorkPlaceId == workplaceId);
            List<WorkplaceIntegrationViewDto> mapDtos = _mapper.Map<List<WorkplaceIntegrationViewDto>>(integrationForWorkPlaces);
            mapDtos.ForEach((item) => { item.IntegrationTypeName = ((IntegrationType)item.IntegrationType).ToString().GetMessageResourceKey(lang); });
            return Result.Success("", 200, 0, mapDtos);
        }
    }
}
