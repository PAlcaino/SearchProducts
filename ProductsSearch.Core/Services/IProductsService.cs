namespace ProductsSearch.Web.Services
{
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Products Service Interface
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Retrieves a List of Products from the Service
        /// </summary>
        /// <returns></returns>
        Task<BaseGatewayResponse<IEnumerable<Product>>> GetProducts();
    }
}