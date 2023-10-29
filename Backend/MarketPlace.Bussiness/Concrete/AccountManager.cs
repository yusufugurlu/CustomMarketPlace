﻿using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
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

namespace MarketPlace.Bussiness.Concrete
{
    public class AccountManager : IAccountService
    {

        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUserAuthorizedLogService _userAuthorizedLogService;
        public AccountManager(IUnitOfWorks unitOfWorks, IConfiguration config, IMapper mapper, IUserAuthorizedLogService userAuthorizedLogService)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
            _config = config;
            _userAuthorizedLogService = userAuthorizedLogService;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
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

        public async Task<ServiceResult> Login(LoginPageDto dto)
        {
            ServiceResult result = new ServiceResult();
            var isHasPerson = (await _userRepository.GetAll(x => x.Email == dto.Mail)).FirstOrDefault();
            if (isHasPerson != null)
            {
                var isControlPerson = (await _userRepository.GetAll(x => x.Email == dto.Mail && x.Password == EncryptionHelper.Encrypt(dto.Password))).FirstOrDefault();
                if (isControlPerson != null)
                {

                    var token = await AddClaims(dto, isControlPerson);
                    token.PersonId = isHasPerson.Id;
                    result.Success = true;
                    result.Message = AlertResource.OperationSuccess;
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
