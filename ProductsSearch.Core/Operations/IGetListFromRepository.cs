namespace ProductsSearch.Core.Operations
{
    using ProductsSearch.Core.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Get List operations of <see cref="{T}"/> Entities From Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGetListFromRepository<T>
    {
        /// <summary>
        /// Gets a list of <see cref="{T}"/> Entities from a given partition key
        /// </summary>
        /// <returns>a list of objects</returns>
        Task<BaseGatewayResponse<IEnumerable<T>>> GetList();

        /// <summary>
        /// Gets a list of <see cref="{T}"/> Entities by a given partition key and filters by a predicate
        /// </summary>
        /// <param name="predicate">filter predicate</param>
        /// <param name="partitionKey">partition key</param>
        /// <returns>a lists of objects</returns>
        Task<BaseGatewayResponse<IEnumerable<T>>> GetList(Expression<Func<T, bool>> predicate);
    }
}
