namespace ProductsSearch.Web.Models
{
    /// <summary>
    /// Represents a single product ViewModel
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Get or Sets Product's Identifier
        /// </summary>
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
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the Product's Price
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// Gets the Product's Offer Price if any
        /// </summary>
        public long OfferPrice { get; set; }

        /// <summary>
        /// Gets the Applied Discount if any
        /// </summary>
        public int AppliedDiscount { get; set; }

        /// <summary>
        /// Determines if the product has any discount, otherwise, false.
        /// </summary>
        public bool HasDiscount => AppliedDiscount > 0 && OfferPrice > 0;
    }
}
