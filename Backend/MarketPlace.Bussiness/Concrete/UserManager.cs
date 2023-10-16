using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Dtos.User;
using MarketPlace.DataTransfer.ServiceResults;
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
                var reult = await _unitOfWorks.SaveChanges();
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
                    SelectedShop = user.SelectedShop

                };

                return Result.Success(data: userInfo);
            }

            return Result.Fail("Kullanıcı bulunamdı.");
        }
    }
}
