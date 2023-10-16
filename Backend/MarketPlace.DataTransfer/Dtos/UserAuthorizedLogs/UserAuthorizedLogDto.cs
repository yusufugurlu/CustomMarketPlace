using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.UserAuthorizedLogs
{
    public class UserAuthorizedLogDto
    {
        public int? UserId { get; set; }
        public DateTime LogDate { get; set; }
        public string IpAddress { get; set; }
        public string Email { get; set; }
        public int AuthorizedLogType { get; set; }
        public string Token { get; set; }
    }
}
