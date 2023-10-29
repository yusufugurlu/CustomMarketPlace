using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.Helper;
using MarketPlace.Common.Extentions;
using MarketPlace.Common.HttpContent;
using MarketPlace.Common.Resources;
using MarketPlace.DataTransfer.Dtos.Account;
using MarketPlace.DataTransfer.Dtos.User;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsersByCompanyId()
        {
            int companyId = SelectedCompany.SelectedCompanyId;
            string lang = CurrentUser.GetCulture();
            var result = await _userService.GetUsersByCompanyId(companyId, lang);
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


        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            int currentUserId = CurrentUser.UserId();
            var result = await _userService.GetUserInfo(currentUserId);
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


        [HttpPost]
        public async Task<IActionResult> ChangeLanguge(CustomLanguageDto dto)
        {
            ServiceResponse response = new ServiceResponse();

            if (LanguageExtention.supportedLanguage.Contains(dto.Language.ToLower()))
            {
                int currentUserId = CurrentUser.UserId();
                var result = await _userService.ChangeLanguage(dto, currentUserId);
                if (result.IsSuccess)
                {

                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(dto.Language);
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

            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = AlertResource.OperationSuccess;
            response.Success = true;

            return BadRequest(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            string lang = CurrentUser.GetCulture();
            int companyId = SelectedCompany.SelectedCompanyId;
            dto.CompanyId = companyId;
            var result = await _userService.CreateUser(dto, lang);
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

        [HttpPost]
        public async Task<IActionResult> UpdateUser(EditUserParameterDto dto)
        {
            string lang = CurrentUser.GetCulture();
            int companyId = SelectedCompany.SelectedCompanyId;
            dto.CompanyId = companyId;
            var result = await _userService.UpdateUser(dto, lang);
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


        [HttpPost]
        public async Task<IActionResult> GetUser(EditUserDto dto)
        {
            string lang = CurrentUser.GetCulture();
            var result = await _userService.GetUser(dto.Id,lang);
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


        [HttpPost]
        public async Task<IActionResult> DeleteUsers(DeleteUserDto dto)
        {
            string lang = CurrentUser.GetCulture();
            var result = await _userService.DeleteUsers(dto.UserIds,lang);
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
