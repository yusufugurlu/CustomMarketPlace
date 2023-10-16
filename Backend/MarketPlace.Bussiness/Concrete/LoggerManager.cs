using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataTransfer.Dtos.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarketPlace.Bussiness.Concrete
{
    public class LoggerManager : ILoggerService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationLogDbContext _context;

        public LoggerManager( IMapper mapper, ApplicationLogDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Log(LogLevel logLevel, string message)
        {
            var logEntry = new DataBaseLogEntry
            {
                LogLevel = logLevel.ToString(),
                Message = message,
                Timestamp = DateTime.Now,
            };

            _context.DataBaseLogEntries.Add(logEntry);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task LogError(ErrorLogDto dto)
        {
            var model = _mapper.Map<ErrorLog>(dto);
            _context.Set<ErrorLog>().Add(model);
            return _context.SaveChangesAsync();
        }
    }
}
