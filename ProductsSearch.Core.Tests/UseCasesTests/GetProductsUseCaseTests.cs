namespace ProductsSearch.Core.Tests.UseCasesTests
{
    using Microsoft.Extensions.Options;
    using Moq;
    using ProductsSearch.Common.Tests;
    using ProductsSearch.Core.Dto;
    using ProductsSearch.Core.Entities;
    using ProductsSearch.Core.Models;
    using ProductsSearch.Core.Operations;
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class GetProductsUseCaseTests
    {
        [Fact]
        public async Task Handle_If_Request_Is_Null_Should_Return_Unsuccesful_Response()
        {
            GetProductsResponse useCaseResponse = null;

            // Mock dependencies
            var mockGetExtensions = new Mock<IGetPagedListFromRepository<Product>>();
            var mockResponsesMessagesSettings = new Mock<IOptions<Dto.ResponsesSettings>>();
            var mockOutput = new Mock<UseCases.IOutputPort<GetProductsResponse>>();

            // Setup
            mockResponsesMessagesSettings
                .Setup(x => x.Value)
                .Returns(TestsConfigurationHelper.ResponsesSettings);

            mockOutput
                .Setup(x => x.Handle(It.IsAny<GetProductsResponse>()))
                .Callback((GetProductsResponse response) =>
                {
                    useCaseResponse = response;
                });

            // Arrange
            var useCase = new GetProductsUseCase(
                mockGetExtensions.Object,
                mockResponsesMessagesSettings.Object);

            GetProductsRequest request = null;

            // Act
            var result = await useCase.Handle(request, mockOutput.Object);

            // Assert
            Assert.False(result);
            Assert.Contains(useCaseResponse.Errores, x => x.Codigo == nameof(TestsConfigurationHelper.ResponsesSettings.RequestMissingErrorMessage));
        }

        [Fact]
        public async Task Handle_If_FilterTerm_Is_Not_Provided_Should_Return_Successful_Response_With_All_Products()
        {
            GetProductsResponse useCaseResponse = null;
            var allProducts = TestModelFactory.GetProductSample();

            // Mock dependencies
            var mockGetProducts = new Mock<IGetPagedListFromRepository<Product>>();
            var mockResponsesMessagesSettings = new Mock<IOptions<Dto.ResponsesSettings>>();
            var mockOutput = new Mock<UseCases.IOutputPort<GetProductsResponse>>();

            // Setup
            mockResponsesMessagesSettings
                .Setup(x => x.Value)
                .Returns(TestsConfigurationHelper.ResponsesSettings);

            mockOutput
                .Setup(x => x.Handle(It.IsAny<GetProductsResponse>()))
                .Callback((GetProductsResponse response) =>
                {
                    useCaseResponse = response;
                });

            mockGetProducts
                .Setup(x => x.GetProducts(It.IsAny<PageParameters>(),It.IsAny<string>()))
                .ReturnsAsync(new BaseGatewayResponse<PagedList<Product>>(allProducts));

            // Arrange
            var useCase = new GetProductsUseCase(
                mockGetProducts.Object,
                mockResponsesMessagesSettings.Object);

            var request = new GetProductsRequest(null);

            // Act
            var result = await useCase.Handle(request, mockOutput.Object);

            // Assert
            Assert.True(result);
            Assert.Equal(useCaseResponse.Products.Count(), allProducts.Count());
        }

        [Fact]
        public async Task Handle_If_FilterTerm_Is_Provided_Should_Return_Successful_Response_With_Filtered_Products()
        {
            GetProductsResponse useCaseResponse = null;
            var allProducts = TestModelFactory.GetProductSample();
            var filterTerm = "brand";

            // Mock dependencies
            var mockGetProducts = new Mock<IGetPagedListFromRepository<Product>>();
            var mockResponsesMessagesSettings = new Mock<IOptions<Dto.ResponsesSettings>>();
            var mockOutput = new Mock<UseCases.IOutputPort<GetProductsResponse>>();

            // Setup
            mockResponsesMessagesSettings
                .Setup(x => x.Value)
                .Returns(TestsConfigurationHelper.ResponsesSettings);

            mockOutput
                .Setup(x => x.Handle(It.IsAny<GetProductsResponse>()))
                .Callback((GetProductsResponse response) =>
                {
                    useCaseResponse = response;
                });

            mockGetProducts
                .Setup(x => x.GetProducts(It.IsAny<PageParameters>(), It.IsAny<string>()))
                .ReturnsAsync(new BaseGatewayResponse<PagedList<Product>>(allProducts));

            // Arrange
            var useCase = new GetProductsUseCase(
                mockGetProducts.Object,
                mockResponsesMessagesSettings.Object);

            var request = new GetProductsRequest(new PageParameters(), filterTerm);

            // Act
            var result = await useCase.Handle(request, mockOutput.Object);

            // Assert
            Assert.True(result);
            Assert.Equal(useCaseResponse.Products.Count(), allProducts.Count());
        }

        [Fact]
        public async Task Handle_If_Filter_Term_Is_Invalid_Should_Return_Unsuccessful_Response()
        {
            GetProductsResponse useCaseResponse = null;
            var allProducts = TestModelFactory.GetProductSample();

            // Mock dependencies
            var mockGetProducts = new Mock<IGetPagedListFromRepository<Product>>();
            var mockResponsesMessagesSettings = new Mock<IOptions<Dto.ResponsesSettings>>();
            var mockOutput = new Mock<UseCases.IOutputPort<GetProductsResponse>>();

            // Setup
            mockResponsesMessagesSettings
                .Setup(x => x.Value)
                .Returns(TestsConfigurationHelper.ResponsesSettings);

            mockOutput
                .Setup(x => x.Handle(It.IsAny<GetProductsResponse>()))
                .Callback((GetProductsResponse response) =>
                {
                    useCaseResponse = response;
                });

            mockGetProducts
               .Setup(x => x.GetProducts(It.IsAny<PageParameters>(), It.IsAny<string>()))
               .ReturnsAsync(new BaseGatewayResponse<PagedList<Product>>(allProducts));

            // Arrange
            var useCase = new GetProductsUseCase(
                mockGetProducts.Object,
                mockResponsesMessagesSettings.Object);

            var request = new GetProductsRequest(new PageParameters(), "&ASDG%&/");

            // Act
            var result = await useCase.Handle(request, mockOutput.Object);

            // Assert
            Assert.False(result);
            Assert.Contains(useCaseResponse.Errores, x => x.Codigo == nameof(TestsConfigurationHelper.ResponsesSettings.InvalidParamErrorMessage));
        }
    }
}
