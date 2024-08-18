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
        private ICloudStorage _cloudStorage;

        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }

        public CategoriesController(ICategoriesService categoriesService, IWebHostEnvironment webhost, ICloudStorage cloudStorage)
        {
            _categoriesService = categoriesService;
            _webhost = webhost;
            _cloudStorage = cloudStorage;
        }

        [HttpGet, HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Index(CategoryAddRequest cat)
        {
            string response = string.Empty;
            if (IsAjaxRequest(Request))
            {
                //response = await cat.SaveImage(_webhost.WebRootPath);
                var name = Guid.NewGuid();
                response = await _cloudStorage.UploadCatImgAsync(cat.ImgFile, name.ToString().ToUpper());
                switch (response)
                {
                    case "succesfully added":
                        cat.ImageGuid = name;
                        await _categoriesService.AddCategory(cat);
                        break;
                }
                return Json(response);

            }
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            return View();
        }


    }
}
