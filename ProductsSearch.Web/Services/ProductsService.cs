namespace ProductsSearch.Web.Services
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Entities;
    using System.Collections.Generic;
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
        public async Task<BaseGatewayResponse<IEnumerable<Product>>> GetProducts()
        {
            List<Error> errors = new List<Error>();

            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetAsync(_apiSettings.BaseUrl + _apiSettings.GetProductsEndpoint);
                if (!response.IsSuccessStatusCode)
                {
                    return new BaseGatewayResponse<IEnumerable<Product>>(new List<Error>() { new Error("Error", "") });
                }

                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseGatewayResponse<IEnumerable<Product>>>(body);
            }
            catch (System.Exception ex)
            {
                errors.Add(new Error(ex.GetType().ToString(), ex.Message));
                return new BaseGatewayResponse<IEnumerable<Product>>(errors);
            }            
        }
    }
}
