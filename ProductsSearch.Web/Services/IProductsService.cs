namespace ProductsSearch.Web.Services
{
    using ProductsSearch.Web.ViewModels;
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
        Task<ProductsViewModel> GetProducts();
    }
}