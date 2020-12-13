namespace ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase
{
    using Mutual.Edocs.Core.UseCases;
    using ProductsSearch.Core.Models;

    ///<inheritdoc cref="IUseCaseRequest{GetProductsResponse}"/>
    public class GetProductsRequest : IUseCaseRequest<GetProductsResponse>
    {
        /// <summary>
        /// Optional Products Filter Term
        /// </summary>
        public string FilterTerm { get; }

        /// <summary>
        /// Page Parameters
        /// </summary>
        public PageParameters PageParameters { get; }

        public GetProductsRequest(PageParameters pageParameters, string filterTerm = null)
        {
            PageParameters = pageParameters;
            FilterTerm = filterTerm;
        }
    }
}
