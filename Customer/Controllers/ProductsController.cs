using Business;
using Business.DTOs;
using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Customer.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private ICustomersService _customersService;


        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, ICustomersService customersService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _customersService = customersService;

        }

        [HttpGet]
        [Route("[action]/{categoryId}")]
        public async Task<IActionResult> Index(int categoryId)
        {
            int totalProductsNumber = await _productsService.GetProductsCountByCategoryId(categoryId);
            int remainder = totalProductsNumber % 12;
            int quotient = totalProductsNumber / 12;
            int totalPages = remainder > 0 ? quotient + 1 : quotient;



            List <CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<ProductResponse> productResponse = await _productsService.GetProductsByPagination(categoryId, 0);
            SingleProductsPage page = new SingleProductsPage() { Products = productResponse, CurrentPage = 0, TotalPages=totalPages };

            return View(page);



        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PaginatedProducts(int categoryId, int pageNumber, int totalPages)
        {

            List<ProductResponse> productResponse = await _productsService.GetProductsByPagination(categoryId, pageNumber);
            SingleProductsPage page = new SingleProductsPage() { Products = productResponse, CurrentPage = pageNumber, TotalPages = totalPages };
            return PartialView("_ProductsPage", page);

        }


    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }

}