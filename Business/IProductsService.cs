using Business.DTOs;
using Business.PageList;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductsService
    {
        Task<List<ProductResponse>> GetAllProductsByCategoryId(int categoryId);
        Task<List<SessionOrder>> GetOrderItems(List<string> ProductsId, List<int> Quantities);
        Task<SessionOrder> GetOneOrderByProductId(int ProductId, int Quantity);
        Task<List<ProductResponse>> GetProductsByPagination(int categoryId, int position);
        Task<int> GetProductsCountByCategoryId(int categoryId);
        Task<List<ProductResponse>> GetProductsByNameSearchWithPagination(string name, int position);
        Task<int> GetProductsCountByNameSearch(string name);
        Task<ProductResponse> UpdateProductById(ProductUpdateRequest product);
        Task<bool> DeleteProductById(int productId, int categoryId);
        IPagedList<ProductResponse> GetProducts(string searchString, int? pageIndex);
    }
}
