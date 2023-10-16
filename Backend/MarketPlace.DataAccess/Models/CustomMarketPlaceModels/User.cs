using MarketPlace.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    public class User: BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? CompanyId { get; set; }
        public LanguageType SelectedLanguage { get; set; }
        public string? PhotoUrl { get; set; }
        /// <summary>
        /// Seçilen Mağaza
        /// </summary>
        public int SelectedShop { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Company Company { get; set; }
        
    }
}
