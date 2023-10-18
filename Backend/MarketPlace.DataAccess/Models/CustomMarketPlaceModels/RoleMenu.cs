using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Common.Enums;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    public class RoleMenu : BaseModel
    {
        
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }

        
    }
}
