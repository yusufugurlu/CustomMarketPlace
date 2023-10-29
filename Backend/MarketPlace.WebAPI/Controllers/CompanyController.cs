using MarketPlace.Bussiness.Abstract;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var result = await _companyService.GetCompanies();
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
        public async Task<IActionResult> GetActiveCompanies()
        {
            var result = await _companyService.GetActiveCompanies();
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
        public async Task<IActionResult> CreateCompany(CreateCompanyDto dto)
        {
            var result = await _companyService.CreateCompany(dto);
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
        public async Task<IActionResult> EditCompany(EditParameterCompanyDto dto)
        {
            var result = await _companyService.EditCompany(dto.Id);
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
        public async Task<IActionResult> DeleteCompanies(DeleteCompanyDto dto)
        {
            string lang = CurrentUser.GetCulture();
            var result = await _companyService.DeleteCompany(dto, lang);
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
