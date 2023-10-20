using MarketPlace.Bussiness.Abstract;
using MarketPlace.Common.HttpContent;
using MarketPlace.Common.Resources;
using MarketPlace.DataTransfer.Dtos;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Dtos.UserAuthorizedLogs;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserAuthorizedLogService _userAuthorizedLogService;
        public AccountController(IAccountService accountService, IUserAuthorizedLogService userAuthorizedLogService)
        {
            _accountService = accountService;
            _userAuthorizedLogService = userAuthorizedLogService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginPageDto LoginPageDto)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr");
            var result = await _accountService.Login(LoginPageDto);
            ServiceResponse response = new ServiceResponse();
            if (result.HttpStatus == (int)HttpStatusCode.OK)
            {
                response.Data = result.Data;
                response.Status = result.HttpStatus;
                response.Message = result.Message;
                response.Success = result.IsSuccess;

                return Ok(response);

            }


            response.Status = result.HttpStatus;
            response.Message = result.Message;
            response.Success = result.IsSuccess;
            return Unauthorized(response);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var user = HttpContext.User;
            var userName = user?.Identity?.Name ?? "";
            var userId = CurrentUser.UserId();
            string tokenVal = "";
            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var token = authHeader.ToString().Replace("Bearer ", "");

                if (!string.IsNullOrEmpty(token))
                {
                    tokenVal = token;
                }
            }
            var result = await _userAuthorizedLogService.Create(new UserAuthorizedLogDto()
            {
                AuthorizedLogType = (int)Common.Enums.AuthorizedLogType.LogOut,
                Email = userName,
                UserId = userId,
                LogDate = DateTime.Now,
                Token = tokenVal,
            });

            ServiceResponse response = new ServiceResponse();

            response.Data = result.Data;
            response.Status = result.HttpStatus;
            response.Message = result.Message;
            response.Success = result.IsSuccess;

            return Ok(response);

        }
    }
}
