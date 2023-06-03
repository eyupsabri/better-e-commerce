using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
