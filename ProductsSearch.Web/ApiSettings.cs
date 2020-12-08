namespace ProductsSearch.Web
{
    /// <summary>
    /// Api Settings Parameters loaded by DI
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Products Api Base Url
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Get Products Endpoint
        /// </summary>
        public string GetProductsEndpoint { get; set; }
    }
}
