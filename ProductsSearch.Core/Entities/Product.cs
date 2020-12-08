namespace ProductsSearch.Core.Entities
{
    /// <summary>
    /// Represent a Business Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Get or Sets Product's Identifier
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Get or Sets Product's Brand
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets or sets the Product's Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets or sets the Product's Image
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// Gets or sets the Product's Price
        /// </summary>
        public long Price { get; private set; }

        /// <summary>
        /// Mapping Constructor
        /// </summary>
        public Product(int id, string brand, string description, string imageUrl, long price)
        {
            Id = id;
            Brand = brand;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
        }
    }
}
