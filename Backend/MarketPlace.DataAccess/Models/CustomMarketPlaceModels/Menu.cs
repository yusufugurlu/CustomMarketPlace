using MarketPlace.DataTransfer.Dtos.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    public class Menu : BaseModel
    {
        public Menu()
        {
            RoleMenus = new HashSet<RoleMenu>();
        }
        public int OrderNumber { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string UIName { get; set; }
        public string Path { get; set; }
        public string CompanentKey { get; set; }
        public int ParentId { get; set; }

        public ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
