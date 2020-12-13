namespace ProductsSearch.Core.Dto
{
    /// <summary>
    /// Represents a Message Response of the API
    /// </summary>
    public class ResponsesSettings
    {
        /// <summary>
        /// Error Message for Missing or null Use Case Requests
        /// </summary>
        public string RequestMissingErrorMessage { get; set; }

        /// <summary>
        /// Error Message for No Entities Found Responses
        /// </summary>
        public string GetNoEntitiesFound { get; set; }

        /// <summary>
        /// Error Message for Internal errors
        /// </summary>
        public string InternalErrorMessage { get; set; }

        /// <summary>
        /// Error Message for Invalid Request Parameters
        /// </summary>
        public string InvalidParamErrorMessage { get; set; }

        /// <summary>
        /// Error Message for failed request to the API
        /// </summary>
        public string RequestErrorMessage { get; set; }
    }
}
