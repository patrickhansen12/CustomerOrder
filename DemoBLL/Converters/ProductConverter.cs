using DemoBLL.BusinessObjects;
using DemoDAL.Entities;

namespace DemoBLL.Converters
{
    public class ProductConverter : IConverter<Product, ProductBO>
    {
        public Product Convert(ProductBO product)
        {
            if (product == null) { return null; }
            return new Product()
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public ProductBO Convert(Product product)
        {
            if (product == null) { return null; }
            return new ProductBO()
            {
                Id = product.Id,
                Name = product.Name
            };
        }
    }
}
