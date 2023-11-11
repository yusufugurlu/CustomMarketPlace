using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.HttpContent;
using MarketPlace.Common.Resources;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.Notifications;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class WorkplaceManager : IWorkplaceService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IGenericRepository<WorkPlace> _workplaceRepository;
        private readonly IGenericRepository<User> _UserRepository;
        public WorkplaceManager(IUnitOfWorks unitOfWorks, IMapper mapper, INotificationService notificationService)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _workplaceRepository = _unitOfWorks.GetGenericRepository<WorkPlace>();
            _UserRepository = _unitOfWorks.GetGenericRepository<User>();
            _notificationService = notificationService;
        }
        public async Task<ServiceResult> CreateWorkPlace(CreateWorklaceDto dto, string lang)
        {
            if (dto != null)
            {
                bool isAdd = false;
                if (dto.Id == 0) //added
                {
                    var workplace = _mapper.Map<WorkPlace>(dto);
                    
                    await _workplaceRepository.Add(workplace);
                    isAdd = true;
                }
                else //updated
                {
                    var workplace = await _workplaceRepository.Get(dto.Id);
                    workplace.Name = dto.Name;
                    workplace.VKN = dto.VKN;
                    workplace.Code = dto.Code;
                    workplace.IsActive = dto.IsActive;
                    await _workplaceRepository.Update(workplace);
                }

                var result = await _unitOfWorks.SaveChanges();
                if (result.IsSuccess && isAdd)
                {
                    var users = await _UserRepository.GetAllToList(x => !x.IsDeleted && x.CompanyId == dto.CompanyId);
                    var userNotifications = users.Select(x => new NotificationUserDto()
                    {
                        Id = x.Id,
                        Language = x.SelectedLanguage.ToString().ToLower(),
                    }).ToList();

                    string messageTr = "WorkplacHasBeenOpened".GetMessageResourceValue("tr").Replace("{x}", dto.Name);
                    string messageEn = "WorkplacHasBeenOpened".GetMessageResourceValue("en").Replace("{x}", dto.Name);
                    await _notificationService.SendNotificationAsync(new DataTransfer.Dtos.NotificationDto()
                    {
                        MessageEn= messageEn,
                        MessageTr=messageTr,
                        DescriptionEn = "NewWorkplace".GetMessageResourceValue("en"),
                        DescriptionTr = "NewWorkplace".GetMessageResourceValue("tr"),
                        NotificationUsers = userNotifications
                    });


                }
                return result;
            }

            return Result.Fail("", 500);
        }

        public async Task<ServiceResult> DeleteWorkPlace(DeleteWorkplaceDto dto)
        {
            var workplaces = (await _workplaceRepository.GetAll(x => !x.IsDeleted && dto.WorkplaceIds.Contains(x.Id))).ToList();

            await _workplaceRepository.DeleteRange(workplaces);
            return await _unitOfWorks.SaveChanges();
        }

        public async Task<ServiceResult> GetWorkPlace(int workplaceId)
        {
            var workplace = (await _workplaceRepository.Get(workplaceId));
            var mapDto = _mapper.Map<WorkplaceDto>(workplace);
            return Result.Success("", 200, 0, mapDto);
        }

        public async Task<ServiceResult> GetActiveWorkPlaces(int companyId)
        {
            string lang = CurrentUser.GetCulture();
            var workPlaces = (await _workplaceRepository.GetAllWithOuthAsNoTracking(x => !x.IsDeleted && x.CompanyId == companyId && x.IsActive)).ToList();
            List<WorkplaceDto> mapDtos = _mapper.Map<List<WorkplaceDto>>(workPlaces);
            mapDtos.ForEach((item) => { item.IsActiveByLang = item.IsActive.ToString().GetMessageResourceKey(lang); });
            return Result.Success("", 200, 0, mapDtos);
        }


        public async Task<ServiceResult> GetWorkPlaces(int companyId)
        {
            string lang = CurrentUser.GetCulture();
            var workPlaces = (await _workplaceRepository.GetAllWithOuthAsNoTracking(x => !x.IsDeleted && x.CompanyId == companyId)).ToList();
            List<WorkplaceDto> mapDtos = _mapper.Map<List<WorkplaceDto>>(workPlaces);
            mapDtos.ForEach((item) => { item.IsActiveByLang = item.IsActive.ToString().GetMessageResourceKey(lang); });
            return Result.Success("", 200, 0, mapDtos);
        }

        public async Task<ServiceResult> UpdateWorkPlaceForCompanyAdmin(CreateWorklaceDto dto)
        {
            if (dto != null)
            {
                var workplace = await _workplaceRepository.Get(dto.Id);
                workplace.Name = dto.Name;
                workplace.VKN = dto.VKN;
                workplace.Code = dto.Code;
                await _workplaceRepository.Update(workplace);
                return await _unitOfWorks.SaveChanges();
            }

            return Result.Fail("", 500);
        }
    }
}
