namespace ProductsSearch.Core.UseCases
{
    /// <summary>
    /// Output Port class that Handles a Response
    /// </summary>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IOutputPort<in TUseCaseResponse>
    {
        /// <summary>
        /// Handles the Use Case Response
        /// </summary>
        /// <param name="response"></param>
        void Handle(TUseCaseResponse response);
    }
}
