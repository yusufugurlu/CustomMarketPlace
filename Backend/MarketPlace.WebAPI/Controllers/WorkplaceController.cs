using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.Helper;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class WorkplaceController : ControllerBase
    {
        private readonly IWorkplaceService _workplaceService;
        public WorkplaceController(IWorkplaceService workplaceService)
        {
            _workplaceService = workplaceService;
        }



        [HttpGet]
        public async Task<IActionResult> GetWorkPlaces()
        {
            var companyId = SelectedCompany.SelectedCompanyId;
            var result = await _workplaceService.GetWorkPlaces(companyId);
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

        [HttpGet]
        public async Task<IActionResult> GetActiveWorkPlaces()
        {
            var companyId = SelectedCompany.SelectedCompanyId;
            var result = await _workplaceService.GetActiveWorkPlaces(companyId);
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
        public async Task<IActionResult> CreateWorkPlace(CreateWorklaceDto dto)
        {
            var companyId = SelectedCompany.SelectedCompanyId;
            string lang =  CurrentUser.GetCulture();
            dto.CompanyId = companyId;
            var result = await _workplaceService.CreateWorkPlace(dto, lang);
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
        public async Task<IActionResult> GetWorkPlace(EditParameterWorkplaceDto dto)
        {
            var result = await _workplaceService.GetWorkPlace(dto.Id);
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
        public async Task<IActionResult> DeleteWorkPlaces(DeleteWorkplaceDto dto)
        {
            var result = await _workplaceService.DeleteWorkPlace(dto);
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
        public async Task<IActionResult> UpdateWorkPlaceForCompanyAdmin(CreateWorklaceDto dto)
        {

            var result = await _workplaceService.UpdateWorkPlaceForCompanyAdmin(dto);
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
