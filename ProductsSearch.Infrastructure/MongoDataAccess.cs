namespace DataAccess
{
    using AutoMapper;
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using ProductsSearch.Core.Entities;
    using ProductsSearch.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides Data Access Methods to a Mongo Database
    /// </summary>
    public class MongoDataAccess : IDataAccess
    {
        private readonly IMongoDBHelper _mongoDBHelper;
        private readonly IMapper _mapper;

        public MongoDataAccess(IMongoDBHelper mongoDBHelper, IMapper mapper)
        {
            _mongoDBHelper = mongoDBHelper;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of products from the repository
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var products = await _mongoDBHelper.GetDocuments<ProductModel>("promotions", "products", null);
                return _mapper.Map<IEnumerable<Product>>(products);
            }
            catch (System.Exception ex)
            {

                throw;
            }
            
        }
    }
}
