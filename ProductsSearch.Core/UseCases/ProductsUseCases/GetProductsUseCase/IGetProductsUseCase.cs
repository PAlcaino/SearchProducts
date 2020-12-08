namespace ProductsSearch.Core.UseCases.ProductsUseCases.GetProductUseCase
{
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase;

    /// <summary>
    /// Retrieves all products from the Repository
    /// </summary>
    public interface IGetProductsUseCase : IUseCaseRequestHandler<GetProductsRequest, GetProductsResponse>
    {
    }
}
