using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProductsByCategoryId(int categoryId);
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product prod);
        Task<Product> UpdateProduct(Product prod);
        Task<bool> DeleteProduct(int id);
    }
}
