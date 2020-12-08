namespace Mutual.Edocs.Core.UseCases
{
    /// <summary>
    /// Represent a Use Case Request for processing
    /// </summary>
    /// <typeparam name="TUseCaseResponse">The Request Processing Response</typeparam>
    public interface IUseCaseRequest<out TUseCaseResponse> { }
}
