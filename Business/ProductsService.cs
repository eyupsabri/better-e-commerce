using Business.DTOs;
using Business.Filter;
using Business.PageList;
using Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Repos;
using System.Linq.Expressions;

namespace Business
{
    public class ProductsService : IProductsService
    {
        private  IProductsRepository productsRepo;
        private ICategoriesService categoriesService;

        public ProductsService(IProductsRepository productsRepository, ICategoriesService categoriesService)
        {
            this.productsRepo = productsRepository;
            this.categoriesService = categoriesService;
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

        public async Task<SessionOrder> GetOneOrderByProductId(int ProductId, int Quantity)
        {
            SessionOrder order = new SessionOrder();
            Product product = await productsRepo.GetProductById(ProductId);
            ProductResponse prod = product.ToProductResponse();
            order.Product = prod;
            order.Quantity = Quantity;
            return order;
            
        }

        public async Task<List<ProductResponse>> GetProductsByPagination(int categoryId, int position)
        {
            List<Product> products = await productsRepo.GetPaginatedProducts(categoryId, position);
            List<ProductResponse> productsResponse = new List<ProductResponse>();
            foreach(Product product in products)
            {
                productsResponse.Add(product.ToProductResponse());
            }
            return productsResponse;
        }

        public async Task<int> GetProductsCountByCategoryId(int categoryId)
        {
            return await productsRepo.GetProductsCountByCategoryId(categoryId);
        }

        public async Task<List<ProductResponse>> GetProductsByNameSearchWithPagination(string name, int position)
        {
            List<Product> filtered = await productsRepo.GetProductsByNameSearchWithPagination(name, position);
            return filtered.Select(x => x.ToProductResponse()).ToList();
        }


        public async Task<ProductResponse> GetProductByProductId(int productId)
        {
            var product = await productsRepo.GetProductById(productId);
            return product.ToProductResponse();


        }

        public async Task<ProductResponse> UpdateProductById(ProductUpdateRequest product)
        {
            Product temp = await productsRepo.UpdateProduct(product.ToProduct());
            return temp.ToProductResponse();
        }

        public async Task<bool> DeleteProductById(int productId, int categoryId)
        {
            await productsRepo.DeleteProduct(productId);
            int totalProducts = await GetProductsCountByCategoryId(categoryId);
            if(totalProducts == 0)
            {
                await categoriesService.DeleteCategoryById(categoryId);
            }
            return true;
        }

        public IPagedList<ProductResponse> GetProducts(ProductFilter products, int? pageIndex = 0)
        {
            var list = productsRepo.GetProducts().FilterAndSort(products);
            
            //var filtered = products.Filter(unfiltered);
            //var sorted = products.Sort(filtered);
            return list.Select(_ => _.ToProductResponse()).ToPagedList(pageIndex.Value, 12);
            
            
            
        }

        
    }


}