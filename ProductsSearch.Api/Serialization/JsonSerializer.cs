namespace ProductsSearch.Api.Serialization
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Custom Json Serializer Class
    /// </summary>
    public sealed class JsonSerializer
    {
        /// <summary>
        /// The Json Serializer Settings
        /// </summary>
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new JsonContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Constructor
        /// </summary>
        public sealed class JsonContractResolver : CamelCasePropertyNamesContractResolver
        {
        }

        /// <summary>
        /// Serializes an object with settings
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
        }
    }
}
