using MarketPlace.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    public class Role : BaseModel
    {
        public Role()
        {
            Users = new HashSet<User>();
            RoleMenus = new HashSet<RoleMenu>();
            
        }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public RoleType RoleType { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
