using Business;
using Business.DTOs;
using Business.Helper;
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


        //Herhangi bir category e bastıgında gelen sayfa 
        [HttpGet]
        [Route("[action]/{categoryId}")]
        public async Task<IActionResult> Index(int categoryId)
        {
            int totalProductsNumber = await _productsService.GetProductsCountByCategoryId(categoryId);
            
            int totalPages = TotalPagesCalculator.CalculatingTotalPages(totalProductsNumber);



            List <CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<ProductResponse> productResponse = await _productsService.GetProductsByPagination(categoryId, 0);
            SingleProductsPage page = new SingleProductsPage() { Products = productResponse, CurrentPage = 0, TotalPages=totalPages, CategoryId = categoryId, CategoryName = productResponse[0].CategoryName };

            return View(page);



        }

         
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PaginatedProducts(int categoryId, int pageNumber)
        {

            List<ProductResponse> productsResponse = await _productsService.GetProductsByPagination(categoryId, pageNumber);
            int totalProductsNumber = await _productsService.GetProductsCountByCategoryId(categoryId);
            int totalPages = TotalPagesCalculator.CalculatingTotalPages(totalProductsNumber);
            SingleProductsPage page = new SingleProductsPage() { Products = productsResponse, CurrentPage = pageNumber, TotalPages = totalPages, CategoryId = categoryId, CategoryName = productsResponse[0].CategoryName };
            return PartialView("_ProductsPage", page);

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SearchProductByNameWithPagination(string searchString, int? pageNumber)
        {
            List<ProductResponse> paginatedProducts = await _productsService.GetProductsByNameSearchWithPagination(searchString, pageNumber == null ? 0 : (int)pageNumber);
            int totalProductsNumber = await _productsService.GetProductsCountByNameSearch(searchString);
            int totalPages = TotalPagesCalculator.CalculatingTotalPages(totalProductsNumber);

            if (pageNumber == null)
            {
                List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
                ViewBag.Categories = categoryResponse;
                ViewBag.CurrentSearchString = searchString;
              
                SingleProductsPage page = new SingleProductsPage() { Products = paginatedProducts, CurrentPage = pageNumber == null ? 0 : (int)pageNumber, TotalPages = (int)totalPages, CurrentSearchString = searchString };
                return View("Index", page);
            }else
            {
                SingleProductsPage page = new SingleProductsPage() { Products = paginatedProducts, CurrentPage = pageNumber == null ? 0 : (int)pageNumber, TotalPages = (int)totalPages, CurrentSearchString = searchString };
                return PartialView("_ProductsPage", page);
            }
                    
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