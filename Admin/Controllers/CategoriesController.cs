using Business;
using Business.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Admin.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoriesService _categoriesService;
        private readonly IWebHostEnvironment _webhost;

        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }

        public CategoriesController(ICategoriesService categoriesService, IWebHostEnvironment webhost)
        {
            _categoriesService = categoriesService;
            _webhost = webhost;
        }

        [HttpGet, HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Index(CategoryAddRequest cat)
        {
            if (IsAjaxRequest(Request))
            {
                if (cat.ImgFile != null)
                {
                    var guid = Guid.NewGuid();
                    var s = Regex.Escape(Path.Combine("Admin", "wwwroot"));
                    var path = Regex.Replace(_webhost.WebRootPath, s, "assets");

                    var imgPath = Path.Combine(path, "category-img", guid + ".jpg");

                    string imgExt = Path.GetExtension(cat.ImgFile.FileName);
                    if (imgExt.Equals(".jpg"))
                    {
                        using (var uploading = new FileStream(imgPath, FileMode.Create))
                        {
                            cat.ImageGuid = guid;
                            await cat.ImgFile.CopyToAsync(uploading);
                            await _categoriesService.AddCategory(cat);
                        }
                        return Json("succesfully added");
                    }
                    else
                    {
                        return Json("Extention must be jpg");
                    }
                }
            }
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            return View();
        }

        
    }
}
