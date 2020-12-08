using DataAccess.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IMongoDataAccess
    {
        IEnumerable<ProductModel> GetItems<T>(IMongoQuery query = null);
    }
}