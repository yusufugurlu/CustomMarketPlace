using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Products
{
    //https://developers.trendyol.com/docs/marketplace/urun-entegrasyonu/urun-aktarma-v2 bakılmalı
    public class CreateTrendyolProductDto
    {
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string ProductMainId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string StockCode { get; set; }
        public decimal DimensionalWeight { get; set; }
        public string Description { get; set; }
        public string CurrencyType { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int CargoCompanyId { get; set; }
        public int? DeliveryDuration { get; set; }
        public string DeliveryOption { get; set; }
        public List<CreateTrendyolImageDto> Images { get; set; }
        public int VatRate { get; set; }
        public int? ShipmentAddressId { get; set; }
        public int? ReturningAddressId { get; set; }
        public List<CreateTrendyolAttributeDto> Attributes { get; set; }
    }
}
