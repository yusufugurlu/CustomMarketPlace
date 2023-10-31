using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IAccountService
    {
        Task<ServiceResult> Login(LoginPageDto dto);
        Task<Token> AddClaims(LoginPageDto dto, User user);
        Token UpdateClaims(LoginPageDto dto, User user);
        Task<ServiceResult> ChangePassword(VerifyPasswordDto dto);
        Task<ServiceResult> CheckHasEmail(ForgotPasswordDto dto);
    }
}
