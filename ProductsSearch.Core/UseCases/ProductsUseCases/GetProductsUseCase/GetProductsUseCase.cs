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

            else if (!message.FilterTerm?.IsAlphaNumeric() ?? false)
                errors.Add(new Error(nameof(_responsesSettings.InvalidParamErrorMessage), string.Format(_responsesSettings.InvalidParamErrorMessage, nameof(message.FilterTerm))));

            if (message is null || errors.Any())
            {
                outputPort.Handle(new GetProductsResponse(errors));
                return false;
            }

            BaseGatewayResponse<IEnumerable<Product>> getProductsResponse = null;

            //Gets the products
            if(string.IsNullOrWhiteSpace(message.FilterTerm))
                getProductsResponse = await _getProductsFromRepository.GetList();
            else
            {
                getProductsResponse = await _getProductsFromRepository.GetList(x => x.Id.Equals(message.FilterTerm) || x.Brand.Equals(message.FilterTerm) || x.Description.Equals(message.FilterTerm));
                
                //Debt: Sets discounts in a service for future discounts scenarios
                if(message.FilterTerm.IsPalindrome())
                {
                    foreach (var product in getProductsResponse.Data)
                    {
                        product.ApplyDiscount(50);
                    }
                }
            }
            
            //Verify Errors
            if (!getProductsResponse.Success)
                errors.AddRange(getProductsResponse.Errors ?? new List<Error>());
            else if (!getProductsResponse.Data?.Any() ?? true)
                errors.Add(new Error(nameof(_responsesSettings.GetNoEntitiesFound), string.Format(_responsesSettings.GetNoEntitiesFound, nameof(Product))));

            outputPort.Handle(!errors.Any() ? new GetProductsResponse(getProductsResponse.Data) : new GetProductsResponse(errors));
            return !errors.Any();
        }
    }
}
