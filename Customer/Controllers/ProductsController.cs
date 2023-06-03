using Business;
using Business.DTOs;
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
        [Route("[action]/{id}")]
        public async Task<IActionResult> ProductsByCategoryId(int id)
        {
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<ProductResponse> productResponse = await _productsService.GetAllProductsByCategoryId(id);
            ViewBag.Products = productResponse;

            return View();
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