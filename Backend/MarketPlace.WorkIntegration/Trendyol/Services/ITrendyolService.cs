using MarketPlace.DataTransfer.Dtos.Integrations;
using MarketPlace.WorkIntegration.Trendyol.Dtos;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Attributes;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Categories;
using MarketPlace.WorkIntegration.Trendyol.Dtos.FilterProducts;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Products;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Providers;
using MarketPlace.WorkIntegration.Trendyol.Dtos.SupplierAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Services
{
    public interface ITrendyolService
    {
        /// <summary>
        /// Trendyol marka listesini getirir.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BrandDto> GetBrands(IntegrationSignInDto dto);
        /// <summary>
        /// Trendyol marka listesini adına göre getirir.
        /// BÜYÜK / küçük harf ayrımına dikkat etmelisiniz. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<List<BrandItemDto>> GetBrandByName(TrendyolBrandGetByNameRequestDto dto);
        /// <summary>
        /// Trendyol Kargo Şirketleri Listesi
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProviderDto> GetProviders(IntegrationSignInDto dto);
        /// <summary>
        /// İade ve Sevkiyat Adres Bilgileri
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<SupplierAddressResponseDto> GetSuppliersAddresses(IntegrationSignInDto dto);
        /// <summary>
        /// createProduct yapmak için en alt seviyedeki kategori ID bilgisi kullanılmalıdır. Seçtiğiniz kategorinin alt kategorileri var ise bu kategori bilgisi ile ürün aktarımı yapamazsınız.
        /// Yeni kategoriler eklenebileceği sebebiyle güncel kategori listesini haftalık olarak almanızı öneririz.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<CategoryResponseDto> GetCategoryTree(IntegrationSignInDto dto);
        /// <summary>
        /// Trendyol Kategori - Özellik Listesi
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<TrendyolAttributeResponseDto> GetCategoryAttributes(TrendyolAttributeRequestDto dto);
        Task<TrendyolProductResponseDto> FilterProducts(IntegrationSignInDto dto);

        Task<TrendyolBatchRequestDto> CreateProduct(IntegrationSignInDto singInDto , CreateTrendyolRequestDto dto);

    }
}
