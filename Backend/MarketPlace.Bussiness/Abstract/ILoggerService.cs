using MarketPlace.DataAccess.Contexts;
using MarketPlace.DataTransfer.Dtos.Errors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface ILoggerService
    {
        Task Log(LogLevel logLevel, string message);
        Task LogError(ErrorLogDto dto);
    }
}
