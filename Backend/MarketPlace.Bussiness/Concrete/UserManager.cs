using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.RolePermission;
using MarketPlace.DataTransfer.Dtos.User;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IAccountService _accountService;
        private readonly IGenericRepository<User> _userRepository;
        public UserManager(IUnitOfWorks unitOfWorks, IAccountService accountService)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _accountService = accountService;

        }

        public async Task<ServiceResult> ChangeLanguage(CustomLanguageDto dto, int userId)
        {
            var user = await _userRepository.Get(userId);
            if (user != null)
            {
                user.SelectedLanguage = dto.Language == "TR" ? LanguageType.TR : LanguageType.EN;
                await _userRepository.Update(user);
                await _unitOfWorks.SaveChanges();
                var data = _accountService.UpdateClaims(new LoginPageDto() { Mail = user.Email }, user);
                return Result.Success("", 200, 0, data);
            }

            return Result.Fail("Kullanıcı bulunamdı.");
        }

        public async Task<ServiceResult> GetUserInfo(int userId)
        {
            var user = await _userRepository.Get(userId);
            if (user != null)
            {
                string language = "";
                if (user.SelectedLanguage.ToString() == "0")
                {
                    language = LanguageType.TR.ToString();
                }
                else
                {
                    language = user.SelectedLanguage.ToString();
                }

                UserInfoDto userInfo = new UserInfoDto()
                {
                    Mail = user.Email,
                    Name = user.Name,
                    SurName = user.SurName,
                    UserRole = user.RoleId,
                    PhotoUrl = user.PhotoUrl?.ToString() ?? "/img/profile/profile-9.webp",
                    SelectedLanguage = language,
                    SelectedShop = user.SelectedShop,
                    SelectedCompany = user.SelectedCompany,

                };

                return Result.Success(data: userInfo);
            }

            return Result.Fail("Kullanıcı bulunamdı.");
        }

        public async Task<ServiceResult> SetSelectCompany(int userId, int companyId)
        {
            var user = (await _userRepository.GetAll(x => x.Id == userId)).Include(x => x.Role).FirstOrDefault();

            if (user != null && user.Role.RoleType == RoleType.SuperAdmin)
            {
    
                user.SelectedCompany= companyId;
                await _userRepository.Update(user);
                return await _unitOfWorks.SaveChanges();
            }
            return Result.Fail();
        }
    }
}
