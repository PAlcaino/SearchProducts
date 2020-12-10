namespace ProductsSearch.Infrastructure.Operations
{
    using AutoMapper;
    using DataAccess.Interfaces;
    using Microsoft.Extensions.Options;
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Entities;
    using ProductsSearch.Core.Operations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    ///<inheritdoc cref="IGetListFromRepository{Product}"/>
    public class GetProductsFromRepository : IGetListFromRepository<Product>
    {
        private readonly IDataAccess _mongoDataBase;
        private readonly IMapper _mapper;
        private readonly ResponsesSettings _responsesSettings;

        public GetProductsFromRepository(IDataAccess mongoDataBase, IMapper mapper, IOptions<ResponsesSettings> responsesSettings)
        {
            _mongoDataBase = mongoDataBase;
            _mapper = mapper;
            _responsesSettings = responsesSettings.Value;
        }

        ///<inheritdoc/>
        public async Task<BaseGatewayResponse<IEnumerable<Product>>> GetList()
        {
            try
            {
                var result = await _mongoDataBase.GetProducts();
                return new BaseGatewayResponse<IEnumerable<Product>>(result);
            }
            catch (Exception ex)
            {
                return new BaseGatewayResponse<IEnumerable<Product>>(
                    new List<Error> { new Error(nameof(_responsesSettings.InternalErrorMessage), _responsesSettings.InternalErrorMessage) });
            }
        }

        ///<inheritdoc/>
        public async Task<BaseGatewayResponse<IEnumerable<Product>>> GetList(Expression<Func<Product, bool>> predicate)
        {
            try
            {
                var result = await _mongoDataBase.GetProducts();
                var filtered = result.Where(predicate.Compile());
                return new BaseGatewayResponse<IEnumerable<Product>>(filtered);
            }
            catch (Exception ex)
            {
                return new BaseGatewayResponse<IEnumerable<Product>>(
                    new List<Error> { new Error(nameof(_responsesSettings.InternalErrorMessage), _responsesSettings.InternalErrorMessage) });
            }
        }
    }
}
