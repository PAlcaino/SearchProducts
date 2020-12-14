namespace ProductsSearch.Web.Models
{
    /// <summary>
    /// Pagination Link 
    /// </summary>
    public class PagingLink
    {
        /// <summary>
        /// Indicates the Text of the Link
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The Current page of the pagination stack
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Determines if this Paging Link is enabled, otherwise, false.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Determines if this Paging Link is active, otherwise, false.
        /// </summary>
        public bool Active { get; set; }

        public PagingLink(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
    }
}
