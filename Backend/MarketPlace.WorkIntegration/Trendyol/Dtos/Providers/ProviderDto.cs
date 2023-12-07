using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Providers
{
    public class ProviderDto
    {
        public ProviderDto(int Id, string Code, string Name, string TaxNumber)
        {
            this.Id = Id;
            this.Code = Code;
            this.Name = Name;
            this.TaxNumber = TaxNumber;
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
    }
}
