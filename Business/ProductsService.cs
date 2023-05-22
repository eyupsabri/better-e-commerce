using Business.DTOs;
using Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Repos;
using System.Linq.Expressions;

namespace Business
{
    public class ProductsService : IProductsService
    {
        private  IProductsRepository productsRepo;

        public ProductsService(IProductsRepository productsRepository) {
            this.productsRepo = productsRepository;
        }

        public async Task<List<ProductResponse>> GetAllProductsByCategoryId(int categoryId)
        {
            List<Product> products = await productsRepo.GetAllProductsByCategoryId(categoryId);
            List<ProductResponse> productsResponse = products.Select(temp => temp.ToProductResponse()).ToList();
            return productsResponse;
        }

        public async Task<List<SessionOrder>> GetOrderItems(List<string> ProductsId, List<int> Quantities)
        {

            List<SessionOrder> Products = new List<SessionOrder>(); 

           for(int i = 0; i < ProductsId.Count; i++)
            {
                Product product = await productsRepo.GetProductById(Int32.Parse(ProductsId[i]));
                SessionOrder order = new SessionOrder();
                order.Product = product.ToProductResponse();
                order.Quantity = Quantities[i];
                Products.Add(order);
            }        
           
            return Products;
        }
    }
}