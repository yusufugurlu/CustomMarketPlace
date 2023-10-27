using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.Common.Helper;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.SelectedUser;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class CommonManager : ICommonService
    {

        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IAccountService _accountService;
        private readonly IRedisService _redisService;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IGenericRepository<WorkPlace> _workplaceRepository;
        public CommonManager(IUnitOfWorks unitOfWorks, IAccountService accountService, IRedisService redisService)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _accountService = accountService;
            _redisService = redisService;
            _companyRepository = _unitOfWorks.GetGenericRepository<Company>();
            _workplaceRepository = _unitOfWorks.GetGenericRepository<WorkPlace>();
        }

        public async Task<ServiceResult> SetSelectCompany(int userId, int companyId)
        {
            var user = (await _userRepository.GetAll(x => x.Id == userId)).Include(x => x.Role).FirstOrDefault();

            if (user != null && user.Role.RoleType == RoleType.SuperAdmin)
            {

                user.SelectedCompany = companyId;
                await _userRepository.Update(user);
                var result = await _unitOfWorks.SaveChanges();
                if (result.Success)
                {
                    var hasValue = _redisService.ExistKey(CacheConstant.SelectedCompany).Result;
                    if (hasValue)
                    {
                        var datas = _redisService.GetDatas<SelectedWorkplaceDto>(CacheConstant.SelectedCompany).Result;
                        var data = datas.FirstOrDefault(x => x.UserId == CurrentUser.UserId());

                        if (data != null)
                        {
                            data.CompanyId = companyId;
                            await _redisService.SetData(CacheConstant.SelectedCompany, datas);
                        }
                        else
                        {
                            SelectedWorkplaceDto dto = new SelectedWorkplaceDto();
                            var company = await _companyRepository.Get(companyId);
                            dto.CompanyId = companyId;
                            dto.CompanyName = company?.Name ?? "";
                            dto.UserId = CurrentUser.UserId();
                            datas.Add(dto);
                            await _redisService.SetData(CacheConstant.SelectedCompany, datas);
                        }
                    }
                    else
                    {
                        List<SelectedWorkplaceDto> selectedWorkplaceDtos = new List<SelectedWorkplaceDto>();
                        var company = await _companyRepository.Get(companyId);
                        selectedWorkplaceDtos.Add(new SelectedWorkplaceDto()
                        {
                            CompanyName = company?.Name ?? "",
                            CompanyId = companyId,
                            UserId=CurrentUser.UserId(),
                        });
                        await _redisService.SetData(CacheConstant.SelectedCompany, selectedWorkplaceDtos);
                    }
                }
                return result;
            }
            return Result.Fail();
        }

        public async Task<ServiceResult> SetSelectWorkplace(int userId, int companyId, int workplaceId)
        {
            var user = (await _userRepository.GetAll(x => x.Id == userId)).FirstOrDefault();

            if (user != null)
            {

                user.SelectedCompany = companyId;
                user.SelectedShop=workplaceId;
                await _userRepository.Update(user);
                var result = await _unitOfWorks.SaveChanges();
                if (result.Success)
                {
                    var hasValue = _redisService.ExistKey(CacheConstant.SelectedCompany).Result;
                    var company = await _companyRepository.Get(companyId);
                    var workPlace = await _workplaceRepository.Get(workplaceId);

                    if (hasValue)
                    {
                        var datas = _redisService.GetDatas<SelectedWorkplaceDto>(CacheConstant.SelectedCompany).Result;
                        var data = datas.FirstOrDefault(x => x.UserId == CurrentUser.UserId());


                        if (data != null)
                        {
                            data.CompanyId = companyId;
                            data.WorkplaceId=workplaceId;
                            data.CompanyName = company?.Name ?? "";
                            data.WorkplaceName = workPlace?.Name ?? "";
                            await _redisService.SetData(CacheConstant.SelectedCompany, datas);
                        }
                        else
                        {
                            SelectedWorkplaceDto dto = new SelectedWorkplaceDto();
                         
                            dto.CompanyId = companyId;
                            dto.CompanyName = company?.Name ?? "";
                            dto.WorkplaceName = workPlace?.Name ?? "";
                            dto.UserId = CurrentUser.UserId();
                            datas.Add(dto);
                            await _redisService.SetData(CacheConstant.SelectedCompany, datas);
                        }
                    }
                    else
                    {
                        List<SelectedWorkplaceDto> selectedWorkplaceDtos = new List<SelectedWorkplaceDto>();
                        selectedWorkplaceDtos.Add(new SelectedWorkplaceDto()
                        {
                            CompanyName = company?.Name ?? "",
                            CompanyId = companyId,
                            WorkplaceId=workplaceId,
                            WorkplaceName=workPlace?.Name ?? "",
                            UserId = CurrentUser.UserId(),
                        });
                        await _redisService.SetData(CacheConstant.SelectedCompany, selectedWorkplaceDtos);
                    }
                }
                return result;
            }
            return Result.Fail();
        }
    }
}
