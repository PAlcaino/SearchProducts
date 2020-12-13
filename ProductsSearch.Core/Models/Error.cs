namespace ProductsSearch.Core.Dto
{
    /// <summary>
    /// Error's Application Class
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The Error's Code
        /// </summary>
        public string Codigo { get; }

        /// <summary>
        /// The Error's Description
        /// </summary>
        public string Descripcion { get; }

        /// <summary>
        /// Error Constructor
        /// </summary>
        /// <param name="codigo">The Error's Code</param>
        /// <param name="descripcion">The Error's Description</param>
        public Error(string codigo, string descripcion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }

        /// <summary>
        /// Returns a String representation of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Codigo}: {Descripcion}";
        }
    }
}
