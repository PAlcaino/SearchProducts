namespace ProductsSearch.Infrastructure
{
    using AutoMapper;
    using System;

    /// <summary>
    /// Mapper configuration Class
    /// </summary>
    public static class MappingProfileConfig
    {
        /// <summary>
        /// Activates the Mapper configuration
        /// </summary>
        /// <returns></returns>
        public static IMapper Activate()
        {
            var config = GetMappingConfig();
            return config.CreateMapper();
        }

        /// <summary>
        /// Returns the Mapper configuration
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration GetMappingConfig()
        {
            return new MapperConfiguration(cfg =>
               {
               });
        }
    }
}
