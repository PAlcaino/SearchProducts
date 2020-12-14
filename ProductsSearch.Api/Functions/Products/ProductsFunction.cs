namespace ProductsSearch.Api.Functions.Products
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Newtonsoft.Json;
    using ProductsSearch.Api.Presenters.ProductsPresenters;
    using ProductsSearch.Core.Models;
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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products/{filterParam?}")] HttpRequest req, string filterParam = null)
        {
            _ = int.TryParse(req.Query["pageNumber"], out int pageNumber);
            _ = int.TryParse(req.Query["pageSize"], out int pageSize);

            var parameters = new PageParameters(pageNumber, pageSize);
            var presenter = new GetProductsPresenter();
            var request = new GetProductsRequest(parameters, filterParam);
            await _getProductsUseCase.Handle(request, presenter);

            if(presenter.PageMetadata != null)
            {
                req.HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(presenter.PageMetadata));
            }
            
            return presenter.ContentResult;
        }
    }
}
