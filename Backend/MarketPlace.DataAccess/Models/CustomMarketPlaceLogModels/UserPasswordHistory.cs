using MarketPlace.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels
{
    public class UserPasswordHistory : BaseModel
    {
        public int UserId { get; set; }
        public string? Password { get; set; }
    }
}
