namespace ProductsSearch.Api.Tests.FunctionsTests
{
    using Microsoft.AspNetCore.Http;
    using Moq;
    using ProductsSearch.Api.Functions.Products;
    using ProductsSearch.Api.Presenters;
    using ProductsSearch.Api.Presenters.ProductsPresenters;
    using ProductsSearch.Common.Tests;
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase;
    using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductUseCase;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class GetProducsFunctionTests
    {
        [Fact]
        public async Task GetDocumentTypes_Should_Trigger_Handle_Once_And_Return_A_Result()
        {
            // Mock dependencies
            var mockUseCase = new Mock<IGetProductsUseCase>(behavior: MockBehavior.Loose);

            static bool handleResponse(GetProductsRequest input, GetProductsPresenter output)
            {
                output.Handle(new GetProductsResponse(TestModelFactory.GetProductSample()));
                return true;
            }

            mockUseCase
                .Setup(da => da.Handle(It.IsNotNull<GetProductsRequest>(), It.IsNotNull<GetProductsPresenter>()))
                .ReturnsAsync((Func<GetProductsRequest, GetProductsPresenter, bool>)handleResponse);

            // Arrange
            var function = new ProductsFunction(mockUseCase.Object);
            var context = new DefaultHttpContext();
            var req = context.Request;

            // Act
            var result = (JsonContentResult)(await function.GetProductsAsync(req));

            // Assert
            mockUseCase.Verify(x => x.Handle(It.IsNotNull<GetProductsRequest>(), It.IsNotNull<GetProductsPresenter>()), Times.Once);
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrWhiteSpace(result.Content));
            Assert.Equal(200, result.StatusCode);
        }
    }
}
