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
    }
}
