using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> ProductsById(int id)
        {
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<ProductResponse> productResponse = await _productsService.GetAllProductsByCategoryId(id);
            ViewBag.Products = productResponse;

            return View();
        }
    }
}
