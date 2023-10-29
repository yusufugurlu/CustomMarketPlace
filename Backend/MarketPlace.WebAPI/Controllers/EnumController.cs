using MarketPlace.Bussiness.Abstract;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EnumController : ControllerBase
    {
        private readonly IEnumService _enumService;
        public EnumController(IEnumService enumService)
        {
            _enumService = enumService;
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _enumService.GetRoles();
            ServiceResponse response = new ServiceResponse();
            if (result.Any())
            {
                response.Data = result;
            }

            response.Status = 200;
            response.Success = result.Any();
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            var result = await _enumService.GetGenders();
            ServiceResponse response = new ServiceResponse();
            if (result.Any())
            {
                response.Data = result;
            }

            response.Status = 200;
            response.Success = result.Any();
            return Ok(response);
        }
    }
}
