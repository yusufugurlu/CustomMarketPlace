using MarketPlace.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    public class Notification : BaseModel
    {
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public int UserId { get; set; }
        public bool IsRead { get; set; }
    }
}
