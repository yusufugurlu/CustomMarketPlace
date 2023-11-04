using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.WorkplaceIntegration
{
    public class CreateWorkplaceIntegrationDto
    {
        public int Id { get; set; }
        public int IntegrationType { get; set; }
        public int WorkPlaceId { get; set; }
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
