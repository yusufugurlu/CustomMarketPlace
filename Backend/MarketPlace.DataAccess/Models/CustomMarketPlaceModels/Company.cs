using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    public class Company : BaseModel
    {
        public Company()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
