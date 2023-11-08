using MarketPlace.Bussiness.Abstract;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.SystemParameter;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SystemParameterController : ControllerBase
    {
        private readonly ISystemParameterService _systemParameterService;
        public SystemParameterController(ISystemParameterService systemParameterService)
        {
            _systemParameterService = systemParameterService;
        }


        [HttpGet]
        public async Task<IActionResult> GetSystemParameters()
        {
            var result = await _systemParameterService.GetSystemParameters();
            ServiceResponse response = new ServiceResponse();
            if (result.Any())
            {
                response.Data = result;
                response.Status = 200;
                response.Message = "";
                response.Success = true;

                return Ok(response);

            }

            response.Status = 500;
            response.Message = "";
            response.Data = result;
            response.Success = false;
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSystemParameter(SystemParameterDto dto)
        {
            var result = await _systemParameterService.UpdateSystemParameter(dto);
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
