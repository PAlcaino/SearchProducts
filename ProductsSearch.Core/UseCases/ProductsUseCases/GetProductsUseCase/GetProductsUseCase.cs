namespace ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase
{
    using Microsoft.Extensions.Options;
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Entities;
    using ProductsSearch.Core.Operations;
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductUseCase;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    ///<inheritdoc cref="IGetProductsUseCase"/>
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IGetListFromRepository<Product> _getProductsFromRepository;
        private readonly ResponsesSettings _responsesSettings;

        public GetProductsUseCase(IGetListFromRepository<Product> getFromRepository, IOptions<ResponsesSettings> responsesSettings)
        {
            _getProductsFromRepository = getFromRepository;
            _responsesSettings = responsesSettings.Value;
        }

        ///<inheritdoc/>
        public async Task<bool> Handle(GetProductsRequest message, IOutputPort<GetProductsResponse> outputPort)
        {
            var errors = new List<Error>();

            if (message is null)
                errors.Add(new Error(nameof(_responsesSettings.RequestMissingErrorMessage), _responsesSettings.RequestMissingErrorMessage));

            if (message is null || errors.Any())
            {
                outputPort.Handle(new GetProductsResponse(errors));
                return false;
            }

            var getProductsResponse = await _getProductsFromRepository.GetList();

            if (!getProductsResponse.Success)
                errors.AddRange(getProductsResponse.Errors ?? new List<Error>());

            else if (!getProductsResponse.Data?.Any() ?? true)
                errors.Add(new Error(nameof(_responsesSettings.GetNoEntitiesFound), string.Format(_responsesSettings.GetNoEntitiesFound, nameof(Product))));

            outputPort.Handle(!errors.Any() ? new GetProductsResponse(getProductsResponse.Data) : new GetProductsResponse(errors));
            return !errors.Any();
        }
    }
}
