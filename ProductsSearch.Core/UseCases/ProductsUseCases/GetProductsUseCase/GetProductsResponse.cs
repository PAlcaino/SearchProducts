namespace ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase
{
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Entities;
    using System.Collections.Generic;

    ///<inheritdoc cref="UseCaseResponseMessage"/>
    public class GetProductsResponse : UseCaseResponseMessage
    {
        /// <summary>
        /// Gets or sets a Lists of Products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Represents an unsuccessfull response of the use case
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="message"></param>
        public GetProductsResponse(IEnumerable<Error> errors, string message = null)
            : base(false, message, errors)
        { }

        /// <summary>
        /// Represents an successfull response of the use case
        /// </summary>
        /// <param name="products">Extensions allowed by edocs</param>
        /// <param name="message">Response Message</param>
        public GetProductsResponse(IEnumerable<Product> products, string message = null)
           : base(true, message)
        {
            Products = products;
        }
    }
}
