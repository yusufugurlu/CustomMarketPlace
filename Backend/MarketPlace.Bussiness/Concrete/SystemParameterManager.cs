using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Helper;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.SystemParameter;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class SystemParameterManager : ISystemParameterService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IRedisService _redisService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<SystemParameter> _systemParameterRepository;

        public SystemParameterManager(IUnitOfWorks unitOfWorks, IRedisService redisService, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _systemParameterRepository = _unitOfWorks.GetGenericRepository<SystemParameter>();
            _redisService = redisService;
            _mapper = mapper;

        }
        public async Task<SystemParameterDto> GetSystemParameterFromCacheOrDatabase()
        {
            bool existInCache = await _redisService.ExistKey(CacheConstant.SystemParameter);
            if (existInCache)
            {
                return await _redisService.GetData<SystemParameterDto>(CacheConstant.SystemParameter);
            }
            else
            {
                var systemParameter = (await _systemParameterRepository
                    .GetAllToList(x => !x.IsDeleted))
                    .LastOrDefault();

  
                var dto = _mapper.Map<SystemParameterDto>(systemParameter);
                await _redisService.SetData(CacheConstant.SystemParameter, dto);
                return dto;
            }
        }

        public async Task<List<SystemParameterDto>> GetSystemParameters()
        {
            var systemParameter = await GetSystemParameterFromCacheOrDatabase();
            if (systemParameter == null)
            {
                return new List<SystemParameterDto>();
            }
           return new List<SystemParameterDto> { systemParameter }; 
        }

        public async Task<ServiceResult> UpdateSystemParameter(SystemParameterDto parameter)
        {
            var systemParameter = (await _systemParameterRepository.GetAllWithOuthAsNoTracking(x => !x.IsDeleted)).AsNoTracking().AsEnumerable().LastOrDefault();

            if (systemParameter == null)
            {
                var model = _mapper.Map<SystemParameter>(parameter);
                model.SmtpPassword= EncryptionHelper.Encrypt(model?.SmtpPassword ?? "");
                await _systemParameterRepository.Add(model);
                return await _unitOfWorks.SaveChanges();
            }
            else
            {
                systemParameter.SmtpHost = parameter.SmtpHost;
                systemParameter.SmtpPort = parameter.SmtpPort;
                systemParameter.SmtpUserName = parameter.SmtpUserName;
                systemParameter.SmtpPassword = EncryptionHelper.Encrypt(parameter?.SmtpPassword ?? "");
                systemParameter.MaximumWorkplaceNumber = parameter.MaximumWorkplaceNumber;
                systemParameter.MaximumWUserNumber = parameter.MaximumUserNumber;
                await _systemParameterRepository.Update(systemParameter);
                var result = await _unitOfWorks.SaveChanges();
                if (result.IsSuccess)
                {
                    await SetRedisServiceSystemParameter(parameter);
                }
                return result;
            }
        }


        private async Task SetRedisServiceSystemParameter(SystemParameterDto dto)
        {
            await _redisService.SetData(CacheConstant.SystemParameter, dto);
        }
    }
}
