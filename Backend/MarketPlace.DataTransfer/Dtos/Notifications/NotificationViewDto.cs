using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Notifications
{
    public class NotificationViewDto
    {
        public string MessageTr { get; set; }
        public string MessageEn { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public int NotificationType { get; set; }
    }
}
