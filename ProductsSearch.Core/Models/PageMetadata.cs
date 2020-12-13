namespace ProductsSearch.Core.Models
{
    /// <summary>
    /// Pagination Metadata Class
    /// </summary>
    public class PageMetadata
    {
        /// <summary>
        /// Indicates the Current page number
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Indicates the total pages number
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Indicates the Page Size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Indicates the amount of items of the page
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Determines if this page has previus pages, otherwise false.
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// Determines if this page has next pages, otherwise false.
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;
    }
}
