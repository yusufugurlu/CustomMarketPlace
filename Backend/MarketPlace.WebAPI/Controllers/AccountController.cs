using MarketPlace.Bussiness.Abstract;
using MarketPlace.Common.Resources;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Net;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

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
    }
}
