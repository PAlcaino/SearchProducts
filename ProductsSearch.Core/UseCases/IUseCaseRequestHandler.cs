namespace ProductsSearch.Core.UseCases
{
    using Mutual.Edocs.Core.UseCases;
    using System.Threading.Tasks;

    /// <summary>
    /// Use Case Request Handler
    /// </summary>
    /// <typeparam name="TUseCaseRequest">The Request for Processing</typeparam>
    /// <typeparam name="TUseCaseResponse">The Request Processing Response</typeparam>
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        /// <summary>
        /// Handles a Use Case Request Processing
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }
}
