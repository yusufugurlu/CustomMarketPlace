using MarketPlace.Bussiness.Abstract;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Dtos.Notifications;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public HangfireController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotificationHangfire(List<NotificationHangfireDto> dtos)
        {
            var result = await _notificationService.SendNotificationHangfireAsync(dtos);
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
