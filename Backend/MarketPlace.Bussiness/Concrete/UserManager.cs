using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.Common.Extentions;
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
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public async Task<ServiceResult> CreateUser(CreateUserDto dto, string lang)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Email == dto.Email);
            if (!users.Any())
            {
                var userModel = new User()
                {
                    Name = dto.Name,
                    SurName = dto.SurName,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    CompanyId = dto.CompanyId,
                    SelectedCompany= dto.CompanyId,
                    Gender = (Gender)dto.Gender,
                    SelectedLanguage = lang == "tr" ? LanguageType.TR : LanguageType.EN,
                    RoleId = dto.RoleId,
                    Password = "",
                };
                await _userRepository.Add(userModel);
                return await _unitOfWorks.SaveChanges();
            }
            else
            {
                var validationEmail = string.Format("EmalIsUsed".GetAlertResourceValue(lang), dto.Email);
                return Result.Fail(validationEmail);
            }
        }

        public async Task<ServiceResult> GetUsersByCompanyId(int companyId, string lang)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Id != 1 && x.CompanyId == companyId);
            List<UserViewDto> userViewDtos = new List<UserViewDto>();
            if (users.Any())
            {
                foreach (var user in users)
                {
                    userViewDtos.Add(new UserViewDto()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        SurName = user.SurName,
                        Email = user.Email,
                        Phone = user.Phone,
                        Role = ((RoleType)user.RoleId).ToString().GetMessageResourceKey(lang),
                        Gender = user.Gender.ToString().GetMessageResourceKey(lang),

                    });
                }

            }

            return Result.Success("", 200, 0, userViewDtos);
        }

        public async Task<ServiceResult> GetUser(int userId, string lang)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Id != 1 && x.Id == userId);
            UserEditViewDto userViewDto = new UserEditViewDto();
            if (users.Any())
            {
                var user = users.FirstOrDefault();
                if (user != null)
                {
                    userViewDto = new UserEditViewDto()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        SurName = user.SurName,
                        Email = user.Email,
                        Phone = user.Phone,
                        RoleId = user.RoleId,
                        Gender = (int)user.Gender,

                    };
                }
            }
            return Result.Success("", 200, 0, userViewDto);
        }

        public async Task<ServiceResult> UpdateUser(EditUserParameterDto dto, string lang)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Id != dto.Id && x.Email == dto.Email);
            if (!users.Any())
            {
                var user = await _userRepository.Get(dto.Id);
                if (user != null)
                {
                    user.Name = dto.Name;
                    user.SurName = dto.SurName;
                    user.Email = dto.Email;
                    user.Phone = dto.Phone;
                    user.Gender = (Gender)dto.Gender;
                    user.RoleId = dto.RoleId;


                    await _userRepository.Update(user);
                    return await _unitOfWorks.SaveChanges();
                }
                else
                {
                    var validationEmail = "UserDoesntExist".GetAlertResourceValue(lang);
                    return Result.Fail(validationEmail);
                }

            }
            else
            {
                var validationEmail = string.Format("EmalIsUsed".GetAlertResourceValue(lang), dto.Email);
                return Result.Fail(validationEmail);
            }
        }

        public async Task<ServiceResult> DeleteUsers(List<int> userIds, string lang)
        {
            var users = (await _userRepository.GetAll(x => !x.IsDeleted && userIds.Contains(x.Id))).ToList();
            if (users.Any())
            {
                await _userRepository.DeleteRange(users);
                return await _unitOfWorks.SaveChanges();
            }
            else
            {
                var validationEmail = "UserDoesntExist".GetAlertResourceValue(lang);
                return Result.Fail(validationEmail);
            }
        }

        public async Task<ServiceResult> CreateUserForNormalRole(CreateUserDto dto, string lang)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Email == dto.Email);
            if (!users.Any() && dto.RoleId !=(int) RoleType.SuperAdmin )
            {
                var userModel = new User()
                {
                    Name = dto.Name,
                    SurName = dto.SurName,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    CompanyId = dto.CompanyId,
                    SelectedCompany = dto.CompanyId,
                    Gender = (Gender)dto.Gender,
                    SelectedLanguage = lang == "tr" ? LanguageType.TR : LanguageType.EN,
                    RoleId = dto.RoleId,
                    Password = "",
                };
                await _userRepository.Add(userModel);
                return await _unitOfWorks.SaveChanges();
            }
            else
            {
                var validationEmail = string.Format("EmalIsUsed".GetAlertResourceValue(lang), dto.Email);
                return Result.Fail(validationEmail);
            }
        }
    }
}
