namespace ProductsSearch.Web.Services
{
    using ProductsSearch.Common.ViewModels;
    using ProductsSearch.Core.Models;
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
        Task<PagingResponse<ProductViewModel>> GetProducts(PageParameters parameters, string searchTerm = null);
    }
}