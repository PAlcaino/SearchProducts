namespace ProductsSearch.Api.Functions.Products
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using ProductsSearch.Api.Presenters.ProductsPresenters;
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase;
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductUseCase;
    using System.Threading.Tasks;

    /// <summary>
    /// Get Products Endpoints
    /// </summary>
    public class ProductsFunction
    {
        private readonly IGetProductsUseCase _getProductsUseCase;

        /// <summary>
        /// Constructor for DI
        /// </summary>
        public ProductsFunction(IGetProductsUseCase useCase)
        {
            _getProductsUseCase = useCase;
        }

        ///<inheritdoc cref="IGetProductsUseCase"/>
        [FunctionName(nameof(GetProductsAsync))]
        public async Task<IActionResult> GetProductsAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
        {
            var presenter = new GetProductsPresenter();
            var request = new GetProductsRequest();
            await _getProductsUseCase.Handle(request, presenter);
            return presenter.ContentResult;
        }
    }
}
