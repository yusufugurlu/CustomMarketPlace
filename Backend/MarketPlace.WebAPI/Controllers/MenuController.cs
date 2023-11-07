using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.Concrete;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IHubContext<ChatHub> _hubService;
        public MenuController(IMenuService menuService, IHubContext<ChatHub> hubService)
        {
            _menuService = menuService;
            _hubService = hubService;
        }


        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            await _hubService.Clients.All.SendAsync("ReceiveMessage", "test");
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
