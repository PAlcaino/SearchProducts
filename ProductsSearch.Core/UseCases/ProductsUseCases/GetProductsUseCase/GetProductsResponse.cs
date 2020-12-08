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
        public IEnumerable<Product> Productos { get; set; }

        /// <summary>
        /// Represents an unsuccessfull response of the use case
        /// </summary>
        /// <param name="errores"></param>
        /// <param name="mensaje"></param>
        public GetProductsResponse(IEnumerable<Error> errores, string mensaje = null)
            : base(false, mensaje, errores)
        { }

        /// <summary>
        /// Represents an successfull response of the use case
        /// </summary>
        /// <param name="products">Extensions allowed by edocs</param>
        /// <param name="mensaje">Response Message</param>
        public GetProductsResponse(IEnumerable<Product> products, string mensaje = null)
           : base(true, mensaje)
        {
            Productos = products;
        }
    }
}
