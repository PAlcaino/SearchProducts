namespace ProductsSearch.Web.Services
{
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using ProductsSearch.Common.ViewModels;
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides Products Service Methods
    /// </summary>
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="mapper">Mapper Dependency</param>
        public ProductsService(IOptions<ApiSettings> apiSettings, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        /// <inheritdoc/>
        public async Task<PagingResponse<ProductViewModel>> GetProducts(PageParameters parameters, string searchTerm = null)
        {
            List<Error> errors = new List<Error>();

            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var queryStringParam = new Dictionary<string, string>
                {
                    ["pageNumber"] = parameters.PageNumber.ToString()
                };

                var baseUrl = $"{ _apiSettings.BaseUrl}{ _apiSettings.GetProductsEndpoint}";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    baseUrl = $"{baseUrl}{searchTerm}/";
                }

                var productsUrl = $"{QueryHelpers.AddQueryString(baseUrl, queryStringParam)}";

                var response = await _httpClient.GetAsync(productsUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return new PagingResponse<ProductViewModel>
                    {
                        Message = "Ha ocurrido un error al obtener los productos.",
                        Success = false
                    };
                }

                string productsString = await response.Content.ReadAsStringAsync();
                string metaData = response.Headers.GetValues("X-Pagination").First();
                var serviceData = JsonConvert.DeserializeObject<ProductsViewModel>(productsString);
                var pagingResponse = new PagingResponse<ProductViewModel>
                {
                    Items = serviceData.Products,
                    MetaData = JsonConvert.DeserializeObject<PageMetadata>(metaData),
                    Success = serviceData.Success
                };

                return pagingResponse;
            }
            catch (System.Exception ex)
            {
                errors.Add(new Error(ex.GetType().ToString(), ex.Message));
                return new PagingResponse<ProductViewModel>
                {
                    Message = ex.Message
                };
            }
        }
    }
}
