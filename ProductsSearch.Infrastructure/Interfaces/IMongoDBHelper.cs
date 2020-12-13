namespace ProductsSearch.Infrastructure.Interfaces
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Mongo DB Helper Methods
    /// </summary>
    public interface IMongoDBHelper
    {
        /// <summary>
        /// Retrieves all databases and collections
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, List<string>>> GetDatabasesAndCollections();

        /// <summary>
        /// Retrieves a document from a given database and collection names
        /// </summary>
        /// <param name="databaseName">database's name</param>
        /// <param name="collectionName">collection's name</param>
        /// <param name="index">index of the document</param>
        /// <returns>a document</returns>
        Task<BsonDocument> GetDocument(string databaseName, string collectionName, int index);

        /// <summary>
        /// Retrieves a set of documents by a given database and collection names
        /// </summary>
        /// <param name="databaseName">database's name</param>
        /// <param name="collectionName">collection's name</param>
        /// <param name="filter">filter parameter</param>
        /// <returns>a list of documents</returns>
        Task<List<T>> GetDocuments<T>(string databaseName, string collectionName, FilterDefinition<BsonDocument> filter);
    }
}