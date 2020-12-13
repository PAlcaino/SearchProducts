namespace ProductsSearch.Core.Models
{
    /// <summary>
    /// Pagination parameters class
    /// </summary>
    public class PageParameters
    {
        const int maxPageSize = 15;
        const int minPageSize = 1;
        private int pageSize = 4;

        /// <summary>
        /// Indicates the Page number. By Default 1
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the Page Size 
        /// </summary>
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if(value > maxPageSize && value < minPageSize)
                {
                    pageSize = value;
                }
                else
                {
                    pageSize = maxPageSize;
                }
            }
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public PageParameters()
        {

        }

        /// <summary>
        /// Constructor with Parameters
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PageParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
