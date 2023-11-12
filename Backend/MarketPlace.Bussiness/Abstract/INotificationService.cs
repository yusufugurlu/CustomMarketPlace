using MarketPlace.DataTransfer.Dtos;
using MarketPlace.DataTransfer.Dtos.Notifications;
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
        Task<ServiceResult> SendNotificationHangfireAsync(List<NotificationHangfireDto> dtos);
        Task<ServiceResult> GetNotificationForTopMenuByUserId(int userId,string lang);
    }
}
