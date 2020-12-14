namespace ProductsSearch.Infrastructure.Operations
{
    using DataAccess.Interfaces;
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Entities;
    using ProductsSearch.Core.Models;
    using ProductsSearch.Core.Operations;
    using System.Linq;
    using System.Threading.Tasks;

    ///<inheritdoc cref="IGetPagedListFromRepository{Product}"/>
    public class GetPagedProductsFromRepository : IGetPagedListFromRepository<Product>
    {
        private readonly IDataAccess _mongoDataBase;

        public GetPagedProductsFromRepository(IDataAccess mongoDataBase)
        {
            _mongoDataBase = mongoDataBase;
        }

        ///<inheritdoc />
        public async Task<BaseGatewayResponse<PagedList<Product>>> GetProducts(PageParameters parameters, string filterTerm = null)
        {
            var products = await _mongoDataBase.GetProducts();
            if(!string.IsNullOrWhiteSpace(filterTerm))
            {
                products = products.Where(x => x.Id.ToString().Equals(filterTerm) || x.Brand.Equals(filterTerm) || x.Description.Equals(filterTerm));
            }

            return new BaseGatewayResponse<PagedList<Product>>(PagedList<Product>
                .ToPagedList(products, parameters.PageNumber, parameters.PageSize));
        }
    }
}
