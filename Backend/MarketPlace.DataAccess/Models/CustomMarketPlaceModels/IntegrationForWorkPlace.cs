using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Common.Enums;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceModels
{
    
    public class IntegrationForWorkPlace : BaseModel
    {
        
        public int WorkPlaceId { get; set; }
        public WorkPlace WorkPlace { get; set; }
        public virtual IntegrationType IntegrationType { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        /// <summary>
        /// Trendyol Satıcı Id (Cari Id),
        /// HepsiBurada Mağaza Id
        /// istemekte. bu alanı karşılayan datadır.
        /// 
        /// N11 istemediği için boş olabilir
        /// </summary>
        public string? IdForApi { get; set; }
    }
}
