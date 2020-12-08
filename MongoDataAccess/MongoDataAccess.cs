namespace DataAccess
{
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using System.Collections.Generic;

    /// <summary>
    /// Provides Data Access Methods to a Mongo Database
    /// </summary>
    public class MongoDataAccess : IMongoDataAccess
    {
        private readonly MongoDatabase database;

        public MongoDataAccess(IConfiguration configuration)
        {
            //MongoClient client = new MongoClient(configuration.GetConnectionString("ConnectionString"));
            //MongoServer server = client.GetServer();
            //database = server.GetDatabase("test");
        }

        public IEnumerable<ProductModel> GetItems<T>(IMongoQuery query = null)
        {
            var items = new List<ProductModel>()
            {
                new ProductModel
                {
                    Id = 1,
                    Brand = "Chan",
                    Description = "Descripcoin",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 10000
                },
                new ProductModel
                {
                    Id = 2,
                    Brand = "Chan1",
                    Description = "Descripcoin",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 20000
                },
                new ProductModel
                {
                    Id = 3,
                    Brand = "Chan2",
                    Description = "Descripcoin",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 30000
                },
                new ProductModel
                {
                    Id = 4,
                    Brand = "Chan3",
                    Description = "Descripcoin",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 40000
                }
            };

            return items;
        }
    }
}
