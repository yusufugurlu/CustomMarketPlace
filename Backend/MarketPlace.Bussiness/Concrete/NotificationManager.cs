using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos;
using MarketPlace.DataTransfer.Dtos.Notifications;
using MarketPlace.DataTransfer.ServiceResults;
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

        public async Task<ServiceResult> GetNotificationForTopMenuByUserId(int userId, string lang)
        {
            var datas = await _notificationRepository.GetAllToList(x => !x.IsDeleted && !x.IsRead && x.UserId == userId);
            var dtos = datas.OrderByDescending(x=>x.Id).Take(3).Select(x => new NotificationTopLeftMenuDto()
            {
                Id = x.Id,
                Title = lang == "tr" ? x.DescriptionTr : x.DescriptionEn,
                Detail = lang == "tr" ? x.MessageTr : x.MessageEn,
                Link= "#/"
            }).ToList();

            return Result.Success("", 200,0, dtos);
        }

        public async Task SendNotificationAllUserAsync(NotificationDto dto)
        {
            var users = await _userRepository.GetAllToList(x => !x.IsDeleted && x.Id != 1);
            var userIds = users.Select(c => new { c.Id, c.SelectedLanguage }).ToList();
            List<Notification> dtos = new List<Notification>();
            NotificationViewDto viewDto = new NotificationViewDto();

            foreach (var userId in userIds)
            {
                dtos.Add(new Notification()
                {
                    MessageTr = dto.MessageTr,
                    MessageEn = dto.MessageEn,
                    DescriptionTr = dto.DescriptionTr,
                    DescriptionEn = dto.DescriptionEn,
                    NotificationType = (NotificationType)dto.NotificationType,
                    UserId = userId.Id
                });

                viewDto = new NotificationViewDto()
                {
                    NotificationType = dto.NotificationType,
                    MessageTr = dto.MessageTr,
                    MessageEn = dto.MessageEn,
                    DescriptionTr = dto.DescriptionTr,
                    DescriptionEn = dto.DescriptionEn,
                };
            }

            await _notificationRepository.AddRange(dtos);
            var result = await _unitOfWorks.SaveChanges();
            if (result.IsSuccess)
            {
                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                var resultSerialize = JsonConvert.SerializeObject(viewDto, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });
                await _hubService.Clients.All.SendAsync("ReceiveMessage", resultSerialize);
            }

        }

        public async Task SendNotificationAsync(NotificationDto dto)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            List<Notification> dtos = new List<Notification>();
            foreach (var userId in dto.NotificationUsers)
            {
                dtos.Add(new Notification()
                {
                    MessageTr = dto.MessageTr,
                    MessageEn = dto.MessageEn,
                    DescriptionTr = dto.DescriptionTr,
                    DescriptionEn = dto.DescriptionEn,
                    NotificationType = (NotificationType)dto.NotificationType,
                    UserId = Convert.ToInt32(userId.Id)
                });

                var viewDto = new NotificationViewDto()
                {
                    Message = userId.Language == "tr" ? dto.MessageTr : dto.MessageEn,
                    Description = userId.Language == "tr" ? dto.DescriptionTr : dto.DescriptionEn,
                    NotificationType = dto.NotificationType,
                    MessageTr = dto.MessageTr,
                    MessageEn = dto.MessageEn,
                    DescriptionTr = dto.DescriptionTr,
                    DescriptionEn = dto.DescriptionEn,
                };

                var resultSerialize = JsonConvert.SerializeObject(viewDto, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });

                var userIds = new List<string>() { userId.Id.ToString() };
                await _hubService.Clients.Users(userIds).SendAsync("ReceiveMessage", resultSerialize);

            }

            await _notificationRepository.AddRange(dtos);
            await _unitOfWorks.SaveChanges();

        }

        public async Task<ServiceResult> SendNotificationHangfireAsync(List<NotificationHangfireDto> dtos)
        {
            var userIds = dtos.Select(x => x.UserId.ToString()).ToList();
            string message = dtos[0].Message;
            string title = dtos[0].Title;

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var viewDto = new NotificationViewDto()
            {
                Message = message,
                Description = title,
                NotificationType = 0,
                MessageTr = message,
                MessageEn = message,
                DescriptionTr = title,
                DescriptionEn = title,
            };

            var resultSerialize = JsonConvert.SerializeObject(viewDto, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            await _hubService.Clients.Users(userIds).SendAsync("ReceiveMessage", resultSerialize);

            return Result.Success("", 200, 0);
        }
    }
}
