namespace ProductsSearch.Core.UseCases
{
    using ProductsSearch.Core.Dto;
    using System.Collections.Generic;

    /// <summary>
    /// Use Case Response Message
    /// </summary>
    public abstract class UseCaseResponseMessage
    {
        /// <summary>
        /// Gets or sets if the use case succeeded
        /// </summary>
        public bool Success { get; }
        /// <summary>
        /// Gets or sets the response message
        /// </summary>
        public string Mensaje { get; }
        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        public IEnumerable<Error> Errores { get; }

        /// <summary>
        /// Use Case Repsonse Message Constructor
        /// </summary>
        /// <param name="success">Indicates if the sucess of the request</param>
        /// <param name="mensaje">The operation Message result</param>
        /// <param name="errores">The operation Errors if any</param>
        protected UseCaseResponseMessage(bool success = false, string mensaje = null, IEnumerable<Error> errores = null)
        {
            Success = success;
            Mensaje = mensaje;
            Errores = errores;
        }
    }
}
