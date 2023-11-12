using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Enums;
using MarketPlace.Common.Extentions;
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
            var dtos = datas.OrderByDescending(x => x.Id).Take(3).Select(x => new NotificationTopLeftMenuDto()
            {
                Id = x.Id,
                Title = lang == "tr" ? x.DescriptionTr : x.DescriptionEn,
                Detail = lang == "tr" ? x.MessageTr : x.MessageEn,
                Link = "#/"
            }).ToList();

            return Result.Success("", 200, 0, dtos);
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
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            List<Notification> notificationDtos = new List<Notification>();

            foreach (var dto in dtos)
            {
                var messegeDto = GetNotificationHangFireMessage(dto.QueueProcessType, dto.QueueId);
                NotificationLanguageDto titleDto = new NotificationLanguageDto()
                {
                    NameEn = "Information".GetAlertResourceValue("en"),
                    NameTr = "Information".GetAlertResourceValue("tr")
                };
                var viewDto = new NotificationViewDto()
                {
                    Message = messegeDto.NameTr,
                    Description = titleDto.NameTr,
                    NotificationType = 0,
                    MessageTr = messegeDto.NameTr,
                    MessageEn = messegeDto.NameEn,
                    DescriptionTr = titleDto.NameTr,
                    DescriptionEn = titleDto.NameTr,
                };

                notificationDtos.Add(new Notification()
                {
                    MessageTr = messegeDto.NameTr,
                    MessageEn = messegeDto.NameEn,
                    DescriptionTr = titleDto.NameTr,
                    DescriptionEn = titleDto.NameTr,
                    NotificationType = NotificationType.Info,
                    UserId = dto.UserId
                });

                var resultSerialize = JsonConvert.SerializeObject(viewDto, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });

                var userIds = new List<string>() { dto.UserId.ToString() };
                await _hubService.Clients.Users(userIds).SendAsync("ReceiveMessage", resultSerialize);
            }


            await _notificationRepository.AddRange(notificationDtos);
            return await _unitOfWorks.SaveChanges();
        }

        private NotificationLanguageDto GetNotificationHangFireMessage(int processType, int processId)
        {
            QueueProcessType type = (QueueProcessType)processType;
            NotificationLanguageDto dto = new NotificationLanguageDto();

            switch (type)
            {
                case QueueProcessType.InWaiting:
                    dto.NameTr = "ProcessNumberWaitingProcess".GetAlertResourceValue("tr").Replace("{0}", processId.ToString());
                    dto.NameEn = "ProcessNumberWaitingProcess".GetAlertResourceValue("en").Replace("{0}", processId.ToString());
                    break;
                case QueueProcessType.InProcess:
                    dto.NameTr = "TransactionNumberProcessed".GetAlertResourceValue("tr").Replace("{0}", processId.ToString());
                    dto.NameEn = "TransactionNumberProcessed".GetAlertResourceValue("en").Replace("{0}", processId.ToString());
                    break;
                case QueueProcessType.Done:
                    dto.NameTr = "PorecessCompleted".GetAlertResourceValue("tr").Replace("{0}", processId.ToString());
                    dto.NameEn = "PorecessCompleted".GetAlertResourceValue("en").Replace("{0}", processId.ToString());
                    break;
            }

            return dto;
        }
    }
}
