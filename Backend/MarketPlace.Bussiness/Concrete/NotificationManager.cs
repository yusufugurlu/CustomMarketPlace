using MarketPlace.Bussiness.Abstract;
using MarketPlace.DataTransfer.Dtos;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly IHubContext<ChatHub> _hubService;
        public NotificationManager(IHubContext<ChatHub> hubService)
        {
            _hubService = hubService;
        }

        public async Task SendNotificationAllUserAsync(NotificationDto dto)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var result = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            await _hubService.Clients.All.SendAsync("ReceiveMessage", result);
        }

        public async Task SendNotificationAsync(NotificationDto dto, List<string> userIds)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var result = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            await _hubService.Clients.Users(userIds).SendAsync("ReceiveMessage", result);
        }
    }
}
