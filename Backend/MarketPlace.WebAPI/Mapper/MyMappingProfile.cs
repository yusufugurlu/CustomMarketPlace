using AutoMapper;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.Errors;
using MarketPlace.DataTransfer.Dtos.SystemParameter;
using MarketPlace.DataTransfer.Dtos.UserAuthorizedLogs;
using MarketPlace.DataTransfer.Dtos.UserPasswordRecovery;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.Dtos.WorkplaceIntegration;

namespace MarketPlace.WebAPI.Mapper
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            // AutoMapper eşlemelerini burada yapılandırın.
            CreateMap<ErrorLogDto, ErrorLog>().ReverseMap();
            CreateMap<UserAuthorizedLogDto, UserAuthorizedLog>().ReverseMap();
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<CreateCompanyDto, Company>().ReverseMap();
            CreateMap<WorkplaceDto, WorkPlace>().ReverseMap();
            CreateMap<CreateWorklaceDto, WorkPlace>().ReverseMap();
            CreateMap<UserPasswordRecoveryDto, UserPasswordRecovery>().ReverseMap();
            CreateMap<CreateWorkplaceIntegrationDto, IntegrationForWorkPlace>().ReverseMap();
            CreateMap<WorkplaceIntegrationViewDto, IntegrationForWorkPlace>().ReverseMap();
            CreateMap<SystemParameterDto, SystemParameter>().ReverseMap();

        }
    }
}
