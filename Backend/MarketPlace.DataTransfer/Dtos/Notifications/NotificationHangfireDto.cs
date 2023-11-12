using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Notifications
{
    public class NotificationHangfireDto
    {
        public int QueueId { get; set; }
        public int IntegrationType { get; set; }
        public int QueueActionType { get; set; }
        public int QueueProcessType { get; set; }
        public int UserId { get; set; }
    }
}
