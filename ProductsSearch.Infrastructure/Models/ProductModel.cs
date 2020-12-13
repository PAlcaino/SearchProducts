namespace DataAccess.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Represent a Business Product
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Get or Sets Product's Identifier
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ObjectId { get; set; }

        /// <summary>
        /// Get or Sets Product's Identifier
        /// </summary>
        [BsonElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Get or Sets Product's Brand
        /// </summary>
        [BsonElement("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Product's Description
        /// </summary>
        [BsonElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Product's Image
        /// </summary>
        [BsonElement("image")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the Product's Price
        /// </summary>
        [BsonElement("price")]
        public long Price { get; set; }
    }
}
