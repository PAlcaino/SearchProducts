namespace ProductsSearch.Web.Services
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Web.ViewModels;
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
        public async Task<ProductsViewModel> GetProducts(string searchTerm)
        {
            List<Error> errors = new List<Error>();

            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = $"{ _apiSettings.BaseUrl}{ _apiSettings.GetProductsEndpoint}{searchTerm ?? string.Empty}";
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new ProductsViewModel
                    {
                        Message = "Ha ocurrido un error al obtener los productos"
                    };
                }

                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductsViewModel>(body);
            }
            catch (System.Exception ex)
            {
                errors.Add(new Error(ex.GetType().ToString(), ex.Message));
                return new ProductsViewModel
                {
                    Message = ex.Message
                };
            }            
        }
    }
}
