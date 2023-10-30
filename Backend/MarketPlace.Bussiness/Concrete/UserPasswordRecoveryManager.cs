using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Extentions;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.UserPasswordRecovery;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class UserPasswordRecoveryManager : IUserPasswordRecoveryService
    {

        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenericRepository<UserPasswordRecovery> _userPasswordRecoveryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public UserPasswordRecoveryManager(IUnitOfWorks unitOfWorks, IMapper mapper, IEmailService emailService)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
            _userPasswordRecoveryRepository = _unitOfWorks.GetGenericRepository<UserPasswordRecovery>();
            _emailService = emailService;
        }

        public async Task<ServiceResult> CheckGuid(string guidKey, string lang)
        {
            var datetimeNow = DateTime.Now;
            var passwords = await _userPasswordRecoveryRepository.GetAllToList(x => !x.IsDeleted && !x.IsUsed && x.GuidKey == guidKey);
            if (passwords.Any())
            {
                var passwordUser = passwords.FirstOrDefault(x => x.ExpiryDate > datetimeNow);
                if (passwordUser != null)
                {
                    return Result.Success("", 200);
                }
                else
                {
                    return Result.Fail("YourProcessingTimeHasExpired".GetAlertResourceValue(lang));

                }
            }
            else
            {
                return Result.Fail("YourProcessingTimeHasExpired".GetAlertResourceValue(lang));
            }
        }

        public async Task<ServiceResult> CreatePasswordRecovery(UserPasswordRecoveryDto dto)
        {
            var model = _mapper.Map<UserPasswordRecovery>(dto);
            string guid = Guid.NewGuid().ToString();
            DateTime expiryDate = DateTime.Now.AddDays(1).Date;
            model.GuidKey = guid;
            model.ExpiryDate = expiryDate;
            await DeletePasswordRecoveriesByUserId(dto.UserId);
            await _userPasswordRecoveryRepository.Add(model);
            var result = await _unitOfWorks.SaveChanges();
            if (result.IsSuccess)
            {
                await _emailService.SendEmailForPasswordRecovery(dto.UserId, guid);
            }
            return result;

        }

        public async Task<ServiceResult> DeletePasswordRecoveriesByUserId(int userId)
        {
            var recoveries = (await _userPasswordRecoveryRepository.GetAll(x => !x.IsDeleted && !x.IsUsed && x.UserId == userId)).ToList();
            await _userPasswordRecoveryRepository.DeleteRange(recoveries);
            return await _unitOfWorks.SaveChanges();
        }
    }
}
