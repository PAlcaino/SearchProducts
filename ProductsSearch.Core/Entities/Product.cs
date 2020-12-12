namespace ProductsSearch.Core.Entities
{
    /// <summary>
    /// Represent a Business Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Get Product's Identifier
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Get Product's Brand
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets or sets the Product's Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the Product's Image
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// Gets the Product's Price
        /// </summary>
        public long Price { get; private set; }

        /// <summary>
        /// Gets the Product's Offer Price if any
        /// </summary>
        public long OfferPrice { get; private set; }

        /// <summary>
        /// Gets the Applied Discount if any
        /// </summary>
        public int AppliedDiscount { get; private set; }

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

        /// <summary>
        /// Applies a Discount of this Product
        /// </summary>
        /// <param name="percentage"></param>
        public void ApplyDiscount(int percentage)
        {
            if (percentage < 0)
                return;

            this.OfferPrice = Price - (percentage * Price / 100);
            this.AppliedDiscount = percentage;
        }
    }
}
