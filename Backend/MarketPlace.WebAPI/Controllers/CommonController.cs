using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.Helper;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.HttpContent;
using MarketPlace.Common.Resources;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Responses;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly ICommonService _commonService;
        private readonly IRedisService _redisService;
        public CommonController(ICommonService commonService, IRedisService redisService)
        {
            _commonService = commonService;
            _redisService = redisService;
        }


        [HttpGet("{companyId}")]
        public async Task<IActionResult> SetSelectCompany(int companyId)
        {
            int currentUserId = CurrentUser.UserId();
            var result = await _commonService.SetSelectCompany(currentUserId, companyId);
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
            return BadRequest(response);
        }

        [HttpGet("{workplaceId}")]
        public async Task<IActionResult> SetSelectWorkplaceId(int workplaceId)
        {
            int currentUserId = CurrentUser.UserId();
            int companyId = SelectedCompany.SelectedCompanyId;
            var result = await _commonService.SetSelectWorkplace(currentUserId, companyId, workplaceId);
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
            return BadRequest(response);
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllKeys()
        {
            var result = await _redisService.GetAllKeys();
            ServiceResponse response = new ServiceResponse();
            if (result.Any())
            {
                response.Data = result;
                response.Status = 200;
                response.Success = true;

                return Ok(response);

            }

            response.Status = 201;
            response.Success = false;
            return BadRequest(response);
        }


        [HttpPost()]
        public async Task<IActionResult> DeleteDatas(List<string> keys)
        {
            var lang = CurrentUser.GetCulture();
            await _redisService.DeleteDatas(keys);
            ServiceResponse response = new ServiceResponse();
            response.Status = 200;
            response.Message = "OperationSuccess".GetAlertResourceValue(lang);
            response.Success = true;
            return Ok(response);
        }
    }
}
