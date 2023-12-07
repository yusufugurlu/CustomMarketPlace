using MarketPlace.DataTransfer.Dtos.Integrations;
using MarketPlace.WorkIntegration.Trendyol.Dtos;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Attributes;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Categories;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Errors;
using MarketPlace.WorkIntegration.Trendyol.Dtos.FilterProducts;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Products;
using MarketPlace.WorkIntegration.Trendyol.Dtos.Providers;
using MarketPlace.WorkIntegration.Trendyol.Dtos.SupplierAddress;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Services
{
    public class TrendyolManager : ITrendyolService
    {
        private readonly HttpClient _httpClient;

        public TrendyolManager(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<TrendyolBatchRequestDto> CreateProduct(IntegrationSignInDto singInDto, CreateTrendyolRequestDto dto)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{singInDto.AppKey}:{singInDto.AppSecret}"))
                );

                _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");

                string apiUrl = $"https://api.trendyol.com/sapigw/suppliers/{singInDto.CustomKey}/v2/products";

                // Convert DTO to JSON string

                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                string jsonBody = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });


                // Create HttpContent for the request body
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Perform HTTP POST request
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    TrendyolBatchRequestDto trendyolBatchRequestDto = JsonConvert.DeserializeObject<TrendyolBatchRequestDto>(jsonResponse);
                    return trendyolBatchRequestDto;
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    // Deserialize the error response to get details
                    ErrorResponseDto errorDto = JsonConvert.DeserializeObject<ErrorResponseDto>(errorResponse);

                    // Handle the error details as needed
                    foreach (var error in errorDto.Errors)
                    {
                        Console.WriteLine($"Error Key: {error.Key}, Message: {error.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public async Task<TrendyolProductResponseDto> FilterProducts(IntegrationSignInDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
"Basic",
Convert.ToBase64String(Encoding.ASCII.GetBytes($"{dto.AppKey}:{dto.AppSecret}"))
);

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");
            string apiUrl = $"https://api.trendyol.com/sapigw/suppliers/{dto.CustomKey}/products?approved=true";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                TrendyolProductResponseDto trendyolProductResponseDto = JsonConvert.DeserializeObject<TrendyolProductResponseDto>(jsonResponse);
                return trendyolProductResponseDto;
            }
            else
            {
                throw new HttpRequestException($"API isteği başarısız. Durum kodu: {response.StatusCode}");
            }
        }

        public async Task<List<BrandItemDto>> GetBrandByName(TrendyolBrandGetByNameRequestDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
     "Basic",
     Convert.ToBase64String(Encoding.ASCII.GetBytes($"{dto.AppKey}:{dto.AppSecret}"))
 );

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");
            string apiUrl = $"https://api.trendyol.com/sapigw/brands/by-name?name={dto.Name}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<BrandItemDto> brandList = JsonConvert.DeserializeObject<List<BrandItemDto>>(jsonResponse);
                return brandList;
            }
            else
            {
                throw new HttpRequestException($"API isteği başarısız. Durum kodu: {response.StatusCode}");
            }
        }

        public async Task<BrandDto> GetBrands(IntegrationSignInDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{dto.AppKey}:{dto.AppSecret}"))
            );

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");
            string apiUrl = "https://api.trendyol.com/sapigw/brands";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                BrandDto brandList = JsonConvert.DeserializeObject<BrandDto>(jsonResponse);
                return brandList;
            }
            else
            {
                throw new HttpRequestException($"API isteği başarısız. Durum kodu: {response.StatusCode}");
            }
        }

        public async Task<TrendyolAttributeResponseDto> GetCategoryAttributes(TrendyolAttributeRequestDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
"Basic",
Convert.ToBase64String(Encoding.ASCII.GetBytes($"{dto.AppKey}:{dto.AppSecret}"))
);

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");
            string apiUrl = $"https://api.trendyol.com/sapigw/product-categories/{dto.CategoryId}/attributes";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                TrendyolAttributeResponseDto trendyolAttributeResponseDto = JsonConvert.DeserializeObject<TrendyolAttributeResponseDto>(jsonResponse);
                return trendyolAttributeResponseDto;
            }
            else
            {
                throw new HttpRequestException($"API isteği başarısız. Durum kodu: {response.StatusCode}");
            }
        }

        public async Task<CategoryResponseDto> GetCategoryTree(IntegrationSignInDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
"Basic",
Convert.ToBase64String(Encoding.ASCII.GetBytes($"{dto.AppKey}:{dto.AppSecret}"))
);

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");
            string apiUrl = "https://api.trendyol.com/sapigw/product-categories";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                CategoryResponseDto supplierAddressResponseDto = JsonConvert.DeserializeObject<CategoryResponseDto>(jsonResponse);
                return supplierAddressResponseDto;
            }
            else
            {
                throw new HttpRequestException($"API isteği başarısız. Durum kodu: {response.StatusCode}");
            }
        }

        public List<ProviderDto> GetProviders(IntegrationSignInDto dto)
        {
            List<ProviderDto> providerDtos = new List<ProviderDto>();

            providerDtos.Add(new ProviderDto(42, "DHLMP", "DHL Marketplace", "951-241-77-13"));
            providerDtos.Add(new ProviderDto(38, "SENDEOMP", "Sendeo Marketplace", "2910804196"));
            providerDtos.Add(new ProviderDto(36, "NETMP", "NetKargo Lojistik Marketplace", "6930094440"));
            providerDtos.Add(new ProviderDto(34, "MARSMP", "Mars Lojistik Marketplace", "6120538808"));
            providerDtos.Add(new ProviderDto(39, "BIRGUNDEMP", "Bir Günde Kargo Marketplace", "1770545653"));
            providerDtos.Add(new ProviderDto(35, "OCTOMP", "Octovan Lojistik Marketplace", "6330506845"));
            providerDtos.Add(new ProviderDto(30, "BORMP", "Borusan Lojistik Marketplace", "1800038254"));
            providerDtos.Add(new ProviderDto(12, "UPSMP", "UPS Kargo Marketplace", "9170014856"));
            providerDtos.Add(new ProviderDto(13, "AGTMP", "AGT Marketplace", "6090414309"));
            providerDtos.Add(new ProviderDto(14, "CAIMP", "Cainiao Marketplace", "0"));
            providerDtos.Add(new ProviderDto(10, "MNGMP", "MNG Kargo Marketplace", "6080712084"));
            providerDtos.Add(new ProviderDto(19, "PTTMP", "PTT Kargo Marketplace", "7320068060"));
            providerDtos.Add(new ProviderDto(9, "SURATMP", "Sürat Kargo Marketplace", "7870233582"));
            providerDtos.Add(new ProviderDto(17, "TEXMP", "Trendyol Express Marketplace", "8590921777"));
            providerDtos.Add(new ProviderDto(6, "HOROZMP", "Horoz Kargo Marketplace", "4630097122"));
            providerDtos.Add(new ProviderDto(20, "CEVAMP", "CEVA Marketplace", "8450298557"));
            providerDtos.Add(new ProviderDto(4, "YKMP", "Yurtiçi Kargo Marketplace", "3130557669"));
            providerDtos.Add(new ProviderDto(7, "ARASMP", "Aras Kargo Marketplace", "720039666"));

            return providerDtos;
        }

        public async Task<SupplierAddressResponseDto> GetSuppliersAddresses(IntegrationSignInDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
    "Basic",
    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{dto.AppKey}:{dto.AppSecret}"))
);

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");
            string apiUrl = $"https://api.trendyol.com/sapigw/suppliers/{dto.CustomKey}/addresses";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                SupplierAddressResponseDto supplierAddressResponseDto = JsonConvert.DeserializeObject<SupplierAddressResponseDto>(jsonResponse);
                return supplierAddressResponseDto;
            }
            else
            {
                throw new HttpRequestException($"API isteği başarısız. Durum kodu: {response.StatusCode}");
            }
        }
    }
}
