using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.Helper;
using MarketPlace.Common.Resources;
using MarketPlace.Common.TokenHandlers;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Dtos.UserAuthorizedLogs;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.DataTransfer.Dtos.UserPasswordRecovery;

namespace MarketPlace.Bussiness.Concrete
{
    public class AccountManager : IAccountService
    {

        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUnitOfWorksLog _unitOfWorksLog;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserPasswordRecovery> _userPasswordRecoveryRepository;
        private readonly IGenericLogRepository<UserPasswordHistory> _userPasswordHistoryRepository;
        private readonly IConfiguration _config;
        private readonly IUserAuthorizedLogService _userAuthorizedLogService;
        private readonly ICommonService _commonService;
        private readonly IUserPasswordRecoveryService _userPasswordRecoveryService;
        public AccountManager(IUnitOfWorks unitOfWorks, IUnitOfWorksLog unitOfWorksLog, IConfiguration config, IUserAuthorizedLogService userAuthorizedLogService, ICommonService commonService, IUserPasswordRecoveryService userPasswordRecoveryService)
        {
            _unitOfWorks = unitOfWorks;
            _unitOfWorksLog = unitOfWorksLog;
            _config = config;
            _userAuthorizedLogService = userAuthorizedLogService;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _userPasswordRecoveryRepository = _unitOfWorks.GetGenericRepository<UserPasswordRecovery>();
            _commonService = commonService;
            _userPasswordRecoveryService = userPasswordRecoveryService;
            _userPasswordHistoryRepository = _unitOfWorksLog.GetGenericLogRepository<UserPasswordHistory>();
        }

        public async Task<Token> AddClaims(LoginPageDto dto, User user)
        {
            var authClaims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.Name),
                                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                                new Claim("Culture", user.SelectedLanguage.ToString()),
                                 new Claim("SelectedCompany", user.SelectedCompany.ToString()),

                            };

            TokenHandler handler = new TokenHandler(_config);
            Token token = handler.CreateAccessToken(dto, authClaims);
            return token;
        }

        public async Task<ServiceResult> ChangePassword(VerifyPasswordDto dto)
        {
            var userPasswords = await _userPasswordRecoveryRepository.GetAllToList(x => !x.IsDeleted && x.GuidKey == dto.GuidKey);
            if (userPasswords.Any())
            {
                var userPassword = userPasswords.LastOrDefault();
                if (userPassword != null)
                {
                    var user = await _userRepository.Get(userPassword.UserId);
                    if (user != null)
                    {
                        string encyptedPassword = EncryptionHelper.Encrypt(dto.Password);
                        user.Password = encyptedPassword;
                        await _userRepository.Update(user);
                        userPassword.IsUsed = true;
                        await _userPasswordRecoveryRepository.Update(userPassword);
                        var result = await _unitOfWorks.SaveChanges();

                        if (result.Success)
                        {
                            await _userPasswordHistoryRepository.Add(new UserPasswordHistory()
                            {
                                UserId = user.Id,
                                Password = encyptedPassword,
                            });
                            await _unitOfWorksLog.SaveChanges();
                        }

                        return result;
                    }
                }
            }

            var validationEmail = "UserDoesntExist".GetAlertResourceValue("tr");
            return Result.Fail(validationEmail);
        }

        public async Task<ServiceResult> CheckHasEmail(ForgotPasswordDto dto)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Email == dto.Email);
            if (users.Any())
            {
                var user = users.LastOrDefault();
                if (user != null)
                {
                    await _userPasswordRecoveryService.CreatePasswordRecovery(new UserPasswordRecoveryDto() { UserId = user.Id });
                    return Result.Success("OperationSuccess".GetAlertResourceValue(dto.Lang), 200);
                }

            }

            var validationEmail = "UserDoesntExist".GetAlertResourceValue(dto.Lang);
            return Result.Fail(validationEmail);
        }



        public async Task<ServiceResult> Login(LoginPageDto dto)
        {
            ServiceResult result = new ServiceResult();
            var isHasPerson = (await _userRepository.GetAll(x => !x.IsDeleted && x.Email == dto.Mail)).FirstOrDefault();
            if (isHasPerson != null)
            {
                var isControlPerson = (await _userRepository.GetAllWithOuthAsNoTracking(x => !x.IsDeleted && x.Email == dto.Mail && x.Password == EncryptionHelper.Encrypt(dto.Password))).FirstOrDefault();
                if (isControlPerson != null)
                {
                    await _commonService.SetSelectWorkplace(isControlPerson.Id, isControlPerson?.SelectedCompany ?? 0, isControlPerson.SelectedShop);
                    isControlPerson.SelectedLanguage = dto.Lang == "TR" ? Common.Enums.LanguageType.TR : Common.Enums.LanguageType.EN;
                    await _userRepository.Update(isControlPerson);
                    await _unitOfWorks.SaveChanges();

                   var token = await AddClaims(dto, isControlPerson);
                    token.PersonId = isHasPerson.Id;
                    result.Success = true;
                    result.Message = "OperationSuccess".GetAlertResourceValue(dto.Lang);
                    result.HttpStatus = 200;
                    result.Data = token;


                    await _userAuthorizedLogService.Create(new UserAuthorizedLogDto()
                    {
                        AuthorizedLogType = (int)Common.Enums.AuthorizedLogType.Login,
                        Email = isHasPerson.Email,
                        UserId = isHasPerson.Id,
                        LogDate = DateTime.Now,
                        Token = token.AccessToken,

                    });
                }
                else
                {
                    result.Success = false;
                    result.Message = "Kullanıcı adı veya şifre hatalı.";
                    result.Data = false;
                    result.HttpStatus = 401;

                    await _userAuthorizedLogService.Create(new UserAuthorizedLogDto()
                    {
                        AuthorizedLogType = (int)Common.Enums.AuthorizedLogType.InCorrectEntry,
                        Email = dto?.Mail ?? "",
                        UserId = isHasPerson?.Id ?? 0,
                        LogDate = DateTime.Now,
                    });
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Kullanıcı bulunamadı!";
                result.Data = false;
                result.HttpStatus = 401;
                result.ValidationStatus = 600;

                await _userAuthorizedLogService.Create(new UserAuthorizedLogDto()
                {
                    AuthorizedLogType = (int)Common.Enums.AuthorizedLogType.UserDoesntExist,
                    Email = dto?.Mail ?? "",
                    UserId = isHasPerson?.Id ?? 0,
                    LogDate = DateTime.Now,
                });
            }

            return result;
        }

        public Token UpdateClaims(LoginPageDto dto, User user)
        {
            var authClaims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.Name),
                                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                                new Claim("Culture", user.SelectedLanguage.ToString()),

                            };

            TokenHandler handler = new TokenHandler(_config);
            Token token = handler.UpdateAccessToken(dto, authClaims);
            return token;
        }
    }
}
