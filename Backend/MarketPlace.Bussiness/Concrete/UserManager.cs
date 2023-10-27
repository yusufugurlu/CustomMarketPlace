using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.Common.Helper;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.RolePermission;
using MarketPlace.DataTransfer.Dtos.SelectedUser;
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
        private readonly IGenericRepository<Company> _companyRepository;
        public UserManager(IUnitOfWorks unitOfWorks, IAccountService accountService)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _accountService = accountService;
            _companyRepository = _unitOfWorks.GetGenericRepository<Company>();
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
    }
}
