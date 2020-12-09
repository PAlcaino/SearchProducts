namespace ProductsSearch.Infrastructure.Helpers
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using ProductsSearch.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Mongo DB Helper Methods
    /// </summary>
    public class MongoDBHelper : IMongoDBHelper
    {
        private readonly MongoClient _client;
        private Dictionary<string, List<string>> _databasesAndCollections;

        public MongoDBHelper()
        {
            _client = new MongoClient("mongodb://productListUser:productListPassword@localhost:27017?authSource=admin");
        }

        public async Task<Dictionary<string, List<string>>> GetDatabasesAndCollections()
        {
            if (_databasesAndCollections != null)
                return _databasesAndCollections;

            _databasesAndCollections = new Dictionary<string, List<string>>();
            var databasesResult = _client.ListDatabaseNames();

            await databasesResult.ForEachAsync(async databaseName =>
            {
                var collectionNames = new List<string>();
                var database = _client.GetDatabase(databaseName);
                var collectionNamesResult = database.ListCollectionNames();
                await collectionNamesResult.ForEachAsync(collectionName =>
                {
                    collectionNames.Add(collectionName);
                });
                _databasesAndCollections.Add(databaseName, collectionNames);
            });

            return _databasesAndCollections;
        }

        private IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
        {
            var db = _client.GetDatabase(databaseName);
            return db.GetCollection<BsonDocument>(collectionName);
        }

        public async Task<BsonDocument> GetDocument(string databaseName, string collectionName, int index)
        {
            var collection = GetCollection(databaseName, collectionName);
            BsonDocument document = null;
            await collection.Find(doc => true)
              .Skip(index)
              .Limit(1)
              .ForEachAsync(doc => document = doc);
            return document;
        }

        public async Task<List<T>> GetDocuments<T>(string databaseName, string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = GetCollection(databaseName, collectionName);
            var items = await collection.FindAsync<T>(new BsonDocument());
            return items.ToList();
        }
    }
}
