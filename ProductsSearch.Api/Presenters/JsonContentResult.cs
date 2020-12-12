namespace ProductsSearch.Api.Presenters
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Json Content Result Class
    /// </summary>
    public class JsonContentResult : ContentResult
    {
        /// <summary>
        /// Json Content Result Constructor
        /// </summary>
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
