using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        private ICategoriesService _categoriesService;
        private IProductsService _productsService;

        public HomeController(ICategoriesService categoriesService, IProductsService productsService)
        {
            this._categoriesService = categoriesService;
            this._productsService = productsService;
        }

        [Route("/")]
        [Route("/home")]
        public async Task<IActionResult> Index()
        {
            List<CategoryResponse> categoryResponse =  await _categoriesService.GetAllCategories();
            ViewData["categories"] = categoryResponse;
            
            
            foreach (var category in categoryResponse)
            {
                int count = await _productsService.GetProductsCountByCategoryId(category.CategoryId);
                category.ProductsCount = count;
            }
            
            return View(categoryResponse);
        }
    }
}
