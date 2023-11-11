using MarketPlace.DataTransfer.Dtos;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface INotificationService
    {
        Task SendNotificationAllUserAsync(NotificationDto dto);
        Task SendNotificationAsync(NotificationDto dto);
        Task<ServiceResult> GetNotificationForTopMenuByUserId(int userId,string lang);
    }
}
