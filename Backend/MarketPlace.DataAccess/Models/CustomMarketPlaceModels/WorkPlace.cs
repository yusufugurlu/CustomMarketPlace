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
        public string VKN { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string ShortName { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
