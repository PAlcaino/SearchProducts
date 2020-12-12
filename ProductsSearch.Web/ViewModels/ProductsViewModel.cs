namespace ProductsSearch.Web.ViewModels
{
    using ProductsSearch.Web.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Products View Model
    /// </summary>
    public class ProductsViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or Sets a list of products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
    }
}
