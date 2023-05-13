using Store.Model;
using Store.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void EditProduct(Product product)
        {
            Product existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryID = product.CategoryID;
            }
        }

        public void DeleteProduct(int productId)
        {
            Product product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                products.Remove(product);
            }
        }

        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.Id == productId);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}