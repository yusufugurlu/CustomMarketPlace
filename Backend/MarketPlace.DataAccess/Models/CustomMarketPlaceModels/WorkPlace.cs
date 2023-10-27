using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    /// <summary>
    /// Şirkete bağlı mağazaların tablosu
    /// </summary>
    public class WorkPlace : BaseModel
    {
        public WorkPlace()
        {
            IntegrationForWorkPlaces = new HashSet<IntegrationForWorkPlace>();
        }
        public string VKN { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<IntegrationForWorkPlace> IntegrationForWorkPlaces { get; set; }


    }
}
