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
            WorkPlaces = new HashSet<WorkPlace>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<WorkPlace> WorkPlaces { get; set; }

        public int WorkplaceLimit { get; set; }
    }
}
