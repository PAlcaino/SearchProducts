using System.Collections.Generic;

namespace ProductsSearch.Common.ViewModels
{
    /// <summary>
    /// Products View Model
    /// </summary>
    public class ProductsViewModel : BaseResponseViewModel
    {
        /// <summary>
        /// Products Items
        /// </summary>
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
