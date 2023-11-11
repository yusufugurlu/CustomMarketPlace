using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos
{
    public class NotificationDto
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public int NotificationType { get; set; }
    }
}
