using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
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
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenericRepository<Notification> _notificationRepository;
        private readonly IGenericRepository<User> _userRepository;

        public NotificationManager(IHubContext<ChatHub> hubService, IUnitOfWorks unitOfWorks)
        {
            _hubService = hubService;
            _unitOfWorks = unitOfWorks;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
            _notificationRepository = _unitOfWorks.GetGenericRepository<Notification>();
        }

        public async Task SendNotificationAllUserAsync(NotificationDto dto)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Id != 1);
            var userIds = users.Select(c => c.Id).ToList();
            List<Notification> dtos = new List<Notification>();
            foreach (var userId in userIds)
            {
                dtos.Add(new Notification()
                {
                    Message = dto.Message,
                    NotificationType = (NotificationType)dto.NotificationType,
                    UserId = userId
                });
            }

            await _notificationRepository.AddRange(dtos);
            var result = await _unitOfWorks.SaveChanges();
            if (result.IsSuccess)
            {
                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                var resultSerialize = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });
                await _hubService.Clients.All.SendAsync("ReceiveMessage", resultSerialize);
            }

        }

        public async Task SendNotificationAsync(NotificationDto dto, List<string> userIds)
        {
            List<Notification> dtos = new List<Notification>();
            foreach (var userId in userIds)
            {
                dtos.Add(new Notification()
                {
                    Message = dto.Message,
                    NotificationType = (NotificationType)dto.NotificationType,
                    UserId = Convert.ToInt32(userId)
                });
            }

            await _notificationRepository.AddRange(dtos);
            var result = await _unitOfWorks.SaveChanges();

            if (result.IsSuccess)
            {
                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                var resultSerialize = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });

                await _hubService.Clients.Users(userIds).SendAsync("ReceiveMessage", resultSerialize);
            }
        }
    }
}
