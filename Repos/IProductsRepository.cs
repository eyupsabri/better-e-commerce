using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProductsByCategoryId(int categoryId);
        Task<Product> GetProductById(int id);
        Task<bool> AddProduct(Product prod);
        Task<Product> UpdateProduct(Product prod);
        Task<bool> DeleteProduct(int id);
        Task<List<Product>> GetFilteredProducts(Expression<Func<Product, bool>> predicate);

        Task<List<Product>> GetPaginatedProducts(int categoryId, int position);
        Task<int> GetProductsCountByCategoryId(int categoryId);
        Task<List<Product>> GetProductsByNameSearchWithPagination(string name, int position);
        Task<int> GetProductsCountByNameSearch(string name);
        //IQueryable<Product> GetProducts(string searchString, int? categoryId, double? priceUpper = 0, double? priceLower = 0);
        IQueryable<Product> GetProducts();
    }
}
