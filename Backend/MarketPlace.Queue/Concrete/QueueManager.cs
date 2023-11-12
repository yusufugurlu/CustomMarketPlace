using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Helper;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Notifications;
using MarketPlace.Queue.Abstract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Queue.Concrete
{
    public class QueueManager : IQueueService
    {
        private readonly IUnitOfWorksLog _unitOfWorks;
        private readonly IConfiguration _configuration;
        private readonly IGenericLogRepository<CustomQueue> _customQueueRepository;
        public QueueManager(IUnitOfWorksLog unitOfWorks, IConfiguration configuration)
        {
            _unitOfWorks = unitOfWorks;
            _configuration = configuration;
            _customQueueRepository = _unitOfWorks.GetGenericLogRepository<CustomQueue>();

        }
        public async Task RunQueueAsync()
        {
            var integrations = await _customQueueRepository.GetAll(x => x.QueueProcessType == Common.Enums.QueueProcessType.InWaiting);
            await SendNotificationAsync(new List<CustomQueue>()
            {
                new CustomQueue()
                {
                    Id=1,
                    UserId=1
                }
            });
        }


        private async Task SendNotificationAsync(List<CustomQueue> queues)
        {
            List<NotificationHangfireDto> notificationHangfireDtos = new List<NotificationHangfireDto>();

            foreach (var queue in queues)
            {
                notificationHangfireDtos.Add(new NotificationHangfireDto()
                {
                    UserId = queue.UserId,
                    QueueId = queue.Id,
                    Title = "edfsds",
                    Message = "dsadas"
                });
            }

            string connectionType = DatabaseConnectConfiguration.ConnectionString();
            string apiUrl = _configuration.GetSection("BackendUrl")[connectionType]?.ToString() ?? "";
            string fullPathApiUr = apiUrl + "Hangfire/SendNotificationHangfire";

            string guidHeaderValue = _configuration.GetSection("SignalRKey")[connectionType]?.ToString() ?? ""; 
            string jsonData = JsonConvert.SerializeObject(notificationHangfireDtos);

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, fullPathApiUr);
                request.Headers.Add("SignalRKey", guidHeaderValue);

                if (!string.IsNullOrEmpty(jsonData))
                {
                    request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }

               await httpClient.SendAsync(request);
            }
        }
    }
}
