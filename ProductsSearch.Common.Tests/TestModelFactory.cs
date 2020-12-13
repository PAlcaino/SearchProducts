namespace ProductsSearch.Common.Tests
{
    using DataAccess.Models;
    using ProductsSearch.Core.Entities;
    using ProductsSearch.Core.Models;
    using System.Collections.Generic;

    public static class TestModelFactory
    {
        /// <summary>
        /// Products Sample
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProductModel> GetProductModelsSample()
        {
            return new List<ProductModel>()
            {
                new ProductModel
                {
                    Id = 1,
                    Brand = "Producto1",
                    Description = "Descripción1",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 10000
                },
                new ProductModel
                {
                    Id = 2,
                    Brand = "Producto2",
                    Description = "Descripción2",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 20000
                },
                new ProductModel
                {
                    Id = 3,
                    Brand = "Producto3",
                    Description = "Descripción3",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 30000
                },
                new ProductModel
                {
                    Id = 4,
                    Brand = "Producto4",
                    Description = "Descripción4",
                    ImageUrl = "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]",
                    Price = 40000
                }
            };
        }

        /// <summary>
        /// Products Sample
        /// </summary>
        /// <returns></returns>
        public static PagedList<Product> GetProductSample()
        {
            var items = new List<Product>()
            {
                new Product(1, "Marca1", "Descripcion1", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 1000),
                new Product(1, "Marca2", "Descripcion2", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 2000),
                new Product(1, "Marca3", "Descripcion3", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 3000),
                new Product(1, "Marca4", "Descripcion4", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 4000),
                new Product(1, "Marca5", "Descripcion5", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 5000),
                new Product(1, "Marca6", "Descripcion6", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 6000),
                new Product(1, "Marca7", "Descripcion7", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 7000),
                new Product(1, "Marca8", "Descripcion8", "https://images.lider.cl/wmtcl?set=imageSize[medium],imageURL[file:/productos/BNDLSKU_20000278a.jpg],options[progressive]&call=url[file:catalog/sizing.chain]&sink=format[jpg],options[progressive]", 8000)
            };

            return new PagedList<Product>(items, items.Count, 1, 50);
        }
    }
}
