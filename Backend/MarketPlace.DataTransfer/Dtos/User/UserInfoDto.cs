using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.User
{
    public class UserInfoDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public int UserRole { get; set; }
        public string SelectedLanguage { get; set; }
        public string? PhotoUrl { get; set; }
        public int SelectedShop { get; set; }
        public string FullName
        {
            get { return Name +" "+ SurName; }
        }

    }
}
