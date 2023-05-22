using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        private ICategoriesService _categoriesService;

        public HomeController(ICategoriesService categoriesService) {
            this._categoriesService = categoriesService;
        }

        [Route("/")]
        [Route("/home")]
        public async Task<IActionResult> Index()
        {
            List<CategoryResponse> categoryResponse =  await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;
            return View();
        }
    }
}
