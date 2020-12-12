namespace ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase
{
    using Mutual.Edocs.Core.UseCases;

    ///<inheritdoc cref="IUseCaseRequest{GetProductsResponse}"/>
    public class GetProductsRequest : IUseCaseRequest<GetProductsResponse>
    {
        /// <summary>
        /// Optional Products Filter Term
        /// </summary>
        public string FilterTerm { get; set; }

        public GetProductsRequest(string filterTerm = null)
        {
            FilterTerm = filterTerm;
        }
    }
}
