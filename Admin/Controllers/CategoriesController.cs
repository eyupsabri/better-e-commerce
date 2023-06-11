using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
