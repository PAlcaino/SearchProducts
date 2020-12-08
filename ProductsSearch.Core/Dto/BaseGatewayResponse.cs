namespace ProductsSearch.Core.Dto
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Base Response
    /// </summary>
    public class BaseGatewayResponse
    {
        /// <summary>
        /// Indicates if an operation was successful
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// The Errors Collection if any
        /// </summary>
        public IEnumerable<Error> Errors { get; }

        /// <summary>
        /// Base Gate way Constructor
        /// </summary>
        /// <param name="success">Indicates if an operation was successful</param>
        /// <param name="errors">The Errors Collection if any</param>

        public BaseGatewayResponse(bool success = false, IEnumerable<Error> errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }

    /// <summary>
    /// Represents a Generic Base Response with data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseGatewayResponse<T> : BaseGatewayResponse
    {
        /// <summary>
        /// The Response Data Object
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Response Constructor with errors
        /// </summary>
        /// <param name="errors">The Error Collection</param>
        public BaseGatewayResponse(IEnumerable<Error> errors = null)
            : base(false, errors)
        { }

        /// <summary>
        /// Response Constructor with data
        /// </summary>
        /// <param name="data"></param>
        public BaseGatewayResponse(T data)
            : base(true, null)
        {
            Data = data;
        }
    }
}
