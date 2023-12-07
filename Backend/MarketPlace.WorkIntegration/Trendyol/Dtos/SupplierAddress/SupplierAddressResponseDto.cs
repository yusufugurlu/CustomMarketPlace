using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.SupplierAddress
{
    public class SupplierAddressResponseDto
    {
        public List<SupplierAddress> SupplierAddresses { get; set; }
        public DefaultShipmentAddress DefaultShipmentAddress { get; set; }
        public DefaultInvoiceAddress DefaultInvoiceAddress { get; set; }
        public DefaultReturningAddress DefaultReturningAddress { get; set; }
    }
}
