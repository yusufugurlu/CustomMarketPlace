using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.Helper;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.Dtos.WorkplaceIntegration;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class WorkplaceIntegrationController : ControllerBase
    {
        private readonly IWorkplaceIntegrationService _workplaceIntegrationService;
        public WorkplaceIntegrationController(IWorkplaceIntegrationService workplaceIntegrationService)
        {
            _workplaceIntegrationService = workplaceIntegrationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetIntegrations()
        {
            var workplaceId = SelectedCompany.SelectedWorkplaceId;
            var result = await _workplaceIntegrationService.GetIntegrations(workplaceId);
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
        public async Task<IActionResult> CreateIntegration(CreateWorkplaceIntegrationDto dto)
        {
            var lang = CurrentUser.GetCulture();
            var workplaceId = SelectedCompany.SelectedWorkplaceId;
            dto.WorkPlaceId = workplaceId;
            var result = await _workplaceIntegrationService.CreateIntegration(dto, lang);
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
        public async Task<IActionResult> GetIntegration(EditParameterWorkplaceIntegrationDto dto)
        {
            var lang = CurrentUser.GetCulture();
            var result = await _workplaceIntegrationService.GetIntegration(dto.Id,lang);
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
        public async Task<IActionResult> DeleteIntegration(DeleteWorkplaceIntegrationDto dto)
        {
            var lang = CurrentUser.GetCulture();
            var result = await _workplaceIntegrationService.DeleteIntegration(dto, lang);
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
