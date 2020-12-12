namespace DataAccess.Interfaces
{
    using ProductsSearch.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Data Access Methods
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// Retrieves a list of items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts();
    }
}