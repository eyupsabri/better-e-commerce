using Business.DTOs;
using Entities;
using Repositories;

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
    }
}