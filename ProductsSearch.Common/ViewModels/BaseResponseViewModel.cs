using ProductsSearch.Core.Dto;

namespace ProductsSearch.Common.ViewModels
{
    /// <summary>
    /// Base ViewModel Properties
    /// </summary>
    public class BaseResponseViewModel
    {
        /// <summary>
        /// Indicates if the response was successful, otherwise false.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Errors if any
        /// </summary>
        public Error[] Errors { get; set; }
    }
}
