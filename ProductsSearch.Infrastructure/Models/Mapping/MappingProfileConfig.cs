namespace ProductsSearch.Infrastructure
{
    using AutoMapper;
    using DataAccess.Models;
    using ProductsSearch.Core.Entities;

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
                   cfg.CreateMap<ProductModel, Product>()
                       .ConstructUsing(src => new Product(src.Id, src.Brand, src.Description, src.ImageUrl, src.Price));

                   cfg.CreateMap<ProductModel, Product>()
                       .ForMember(e => e.Id, opts => opts.MapFrom(e => e.Id))
                       .ForMember(e => e.Brand, opts => opts.MapFrom(e => e.Brand))
                       .ForMember(e => e.Description, opts => opts.MapFrom(e => e.Description))
                       .ForMember(e => e.ImageUrl, opts => opts.MapFrom(e => e.ImageUrl))
                       .ForMember(e => e.Price, opts => opts.MapFrom(e => e.Price));
               });
        }
    }
}
