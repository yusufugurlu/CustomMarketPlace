using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataTransfer.Dtos.UserAuthorizedLogs;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class UserAuthorizedLogManager : IUserAuthorizedLogService
    {
        private readonly IGenericLogRepository<UserAuthorizedLog> _userAuthorizedLogRepository;
        private IUnitOfWorksLog _unitOfWorksLog;
        private readonly IMapper _mapper;

        public UserAuthorizedLogManager(IUnitOfWorksLog unitOfWorksLog, IMapper mapper)
        {
            _unitOfWorksLog = unitOfWorksLog;
            _mapper = mapper;
            _userAuthorizedLogRepository = _unitOfWorksLog.GetGenericLogRepository<UserAuthorizedLog>();
        }
        public Task<ServiceResult> Create(UserAuthorizedLogDto dto)
        {
            var model = _mapper.Map<UserAuthorizedLog>(dto);
            model.AuthorizedLogType = (AuthorizedLogType)dto.AuthorizedLogType;
            _userAuthorizedLogRepository.Add(model);
            return _unitOfWorksLog.SaveChanges();
        }
    }
}
