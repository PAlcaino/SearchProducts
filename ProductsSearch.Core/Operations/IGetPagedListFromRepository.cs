using ProductsSearch.Core.Dto;
using ProductsSearch.Core.Models;
using System.Threading.Tasks;

namespace ProductsSearch.Core.Operations
{
    /// <summary>
    /// Get Paged List Operations
    /// </summary>
    public interface IGetPagedListFromRepository<T>
    {
        /// <summary>
        /// Returns a paged list of products
        /// </summary>
        /// <param name="parameters">Pagination Parameters</param>
        /// <param name="filterTerm">Optional search term filter</param>
        /// <returns></returns>
        Task<BaseGatewayResponse<PagedList<T>>> GetProducts(PageParameters parameters, string filterTerm = null);
    }
}
