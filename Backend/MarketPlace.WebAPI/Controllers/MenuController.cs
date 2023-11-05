using MarketPlace.Bussiness.Abstract;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            string lang = CurrentUser.GetCulture();
            var userId= CurrentUser.UserId();
            var result = await _menuService.GetMenus(lang, userId);
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


        [HttpGet("{path}")]
        public async Task<IActionResult> GetBreadcrumbs(string path)
        {
            var lang = CurrentUser.GetCulture();
            var result = await _menuService.GetBreadcrumbs(path, lang);
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
