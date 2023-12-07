using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.FilterProducts
{
    public class TrendyolProductContentDto
    {
        public bool Approved { get; set; }
        public bool Archived { get; set; }
        public List<TrendyolProductAttributeDto> Attributes { get; set; }
        public string Barcode { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public string CategoryName { get; set; }
        public object createDateTime { get; set; }
        public string Description { get; set; }
        public int DimensionalWeight { get; set; }
        public string Gender { get; set; }
        public bool HasActiveCampaign { get; set; }
        public string Id { get; set; }
        public List<TrendyolProductImageDto> Images { get; set; }
        public object LastUpdateDate { get; set; }
        public int ListPrice { get; set; }
        public bool Locked { get; set; }
        public bool OnSale { get; set; }
        public int PimCategoryId { get; set; }
        public string PlatformListingId { get; set; }
        public int ProductCode { get; set; }
        public int ProductContentId { get; set; }
        public string ProductMainId { get; set; }
        public int Quantity { get; set; }
        public int SalePrice { get; set; }
        public int ShipmentAddressId { get; set; }
        public string StockCode { get; set; }
        public string StockUnitType { get; set; }
        public int SupplierId { get; set; }
        public string Title { get; set; }
        public int VatRate { get; set; }
        public int DeliveryDuration { get; set; }
        public bool Rejected { get; set; }
        public List<object> RejectReasonDetails { get; set; }
        public bool Blacklisted { get; set; }
        public TrendyolDeliveryOptionDto DeliveryOptions { get; set; }
    }
}
