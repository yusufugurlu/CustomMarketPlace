using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Common.Enums;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels
{
    public class UserAuthorizedLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime LogDate { get; set; }
        public string? IpAddress { get; set; }
        public string? Email { get; set; }
        public AuthorizedLogType AuthorizedLogType { get; set; }
        public string? Token { get; set; }
    }
}
