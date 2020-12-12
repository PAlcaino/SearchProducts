namespace ProductsSearch.Api.Presenters.ProductsPresenters
{
    using ProductsSearch.Api.Serialization;
    using ProductsSearch.Core.UseCases;
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase;
    using System.Net;

    ///<inheritdoc cref="IOutputPort{GetProductsResponse}"/>
    public class GetProductsPresenter : IOutputPort<GetProductsResponse>
    {
        /// <summary>
        /// Content Result has json
        /// </summary>
        public JsonContentResult ContentResult { get; }

        public GetProductsPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        ///<inheritdoc/>
        public void Handle(GetProductsResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
