using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.Common.Helper;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Notifications;
using MarketPlace.Queue.Abstract;
using MarketPlace.WorkIntegration.Trendyol.Services;
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
        private readonly ITrendyolService _trendyolService;
        private readonly IGenericLogRepository<CustomQueue> _customQueueRepository;
        public QueueManager(IUnitOfWorksLog unitOfWorks, IConfiguration configuration, ITrendyolService trendyolService)
        {
            _unitOfWorks = unitOfWorks;
            _configuration = configuration;
            _trendyolService = trendyolService;
            _customQueueRepository = _unitOfWorks.GetGenericLogRepository<CustomQueue>();

        }
        public async Task RunQueueAsync()
        {       
            var model = new CustomQueue()
            {
                UserId = 1,
                CreatedDate = DateTime.Now,
                IntegrationType = IntegrationType.Hepsiburada,
                QueueActionType = QueueActionType.Get,
                QueueProcessType = QueueProcessType.InWaiting
            };
            await _customQueueRepository.Add(model);
            await _unitOfWorks.SaveChanges();

            //var inProcessQueues = await _customQueueRepository.GetAll(x => x.QueueProcessType == QueueProcessType.InWaiting);
            var list = new List<CustomQueue>() { model };
            await SendNotificationAsync(list);

            await Task.Delay(20000);

            foreach (var item in list)
            {

                item.QueueProcessType = QueueProcessType.InProcess;
                await _customQueueRepository.Update(item);
                await _unitOfWorks.SaveChanges();
                await SendNotificationAsync(list);
                await Task.Delay(10000);

                item.QueueProcessType = QueueProcessType.Done;
                await _customQueueRepository.Update(item);
                await _unitOfWorks.SaveChanges();
                await SendNotificationAsync(list);
            }    
        }


        private async Task SendNotificationAsync(List<CustomQueue> queues)
        {
            if (queues.Count < 1)
            {
                return;
            }

            List<NotificationHangfireDto> notificationHangfireDtos = queues.Select(x => new NotificationHangfireDto()
            {
                QueueId = x.Id,
                IntegrationType = (int)x.IntegrationType,
                QueueActionType = (int)x.QueueActionType,
                QueueProcessType = (int)x.QueueProcessType,
                UserId = x.UserId
            }).ToList();


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
