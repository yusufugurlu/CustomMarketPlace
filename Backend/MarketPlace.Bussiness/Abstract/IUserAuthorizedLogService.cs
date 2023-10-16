using MarketPlace.DataTransfer.Dtos.UserAuthorizedLogs;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IUserAuthorizedLogService
    {
        Task<ServiceResult> Create(UserAuthorizedLogDto dto);
    }
}
