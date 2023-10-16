using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Menus
{
    public class MenuDto
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string UIName { get; set; }
        public string CompanentKey { get; set; }
        public List<MenuDto> SubMenus { get; set; }
    }
}
