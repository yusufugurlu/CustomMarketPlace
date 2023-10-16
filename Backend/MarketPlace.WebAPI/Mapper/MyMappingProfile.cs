using AutoMapper;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataTransfer.Dtos.Errors;
using MarketPlace.DataTransfer.Dtos.UserAuthorizedLogs;

namespace MarketPlace.WebAPI.Mapper
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            // AutoMapper eşlemelerini burada yapılandırın.
            CreateMap<ErrorLogDto, ErrorLog>().ReverseMap();
            CreateMap<UserAuthorizedLogDto, UserAuthorizedLog>().ReverseMap();
        }
    }
}
