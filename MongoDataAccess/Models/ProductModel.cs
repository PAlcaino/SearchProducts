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
        public int Id { get; set; }

        /// <summary>
        /// Get or Sets Product's Brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Product's Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Product's Image
        /// </summary>
        [BsonElement("Image")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the Product's Price
        /// </summary>
        public long Price { get; set; }
    }
}
