using MarketPlace.Bussiness.Abstract;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.UserPasswordRecovery;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserPasswordRecoveryController : ControllerBase
    {
        private readonly IUserPasswordRecoveryService _userPasswordRecoveryService;
        public UserPasswordRecoveryController(IUserPasswordRecoveryService userPasswordRecoveryService)
        {
            _userPasswordRecoveryService = userPasswordRecoveryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePasswordRecovery(UserPasswordRecoveryDto dto)
        {
            var result = await _userPasswordRecoveryService.CreatePasswordRecovery(dto);
            ServiceResponse response = new ServiceResponse();
            if (result.IsSuccess)
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
            return Ok(response);
        }
    }
}
