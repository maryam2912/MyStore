using Store.Model;
using System.Collections.Generic;

namespace Store.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int productId);
        List<Product> GetAllProducts();
    }
}