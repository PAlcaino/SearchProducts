namespace ProductsSearch.Common.ViewModels
{
    using ProductsSearch.Core.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Page Metadata Response from the API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResponse<T> : BaseResponseViewModel
    {
        /// <summary>
        /// Gets or sets a List of Items
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the Page Metadata Info
        /// </summary>
        public PageMetadata MetaData { get; set; }
    }
}
