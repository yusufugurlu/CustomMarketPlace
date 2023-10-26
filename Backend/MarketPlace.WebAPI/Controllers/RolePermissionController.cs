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
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _rolePermissionService;
        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyByUserId()
        {
            var userId = CurrentUser.UserId();
            var result = await _rolePermissionService.GetCompanyByUserId(userId);
            ServiceResponse response = new ServiceResponse();
            if (result.Any())
            {
                response.Status = 200;
                response.Data = result;
                response.Success = true;

                return Ok(response);

            }


            response.Status = 500;
            return Ok(response);
        }

    }
}
