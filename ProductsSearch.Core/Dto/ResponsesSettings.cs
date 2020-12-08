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
        public string NoEntitiesFound { get; set; }
    }
}
