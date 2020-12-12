namespace ProductsSearch.Web.ViewModels
{
    /// <summary>
    /// Base ViewModel Properties
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Indicates if the response was successful, otherwise false.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a message
        /// </summary>
        public string Message { get; set; }
    }
}
