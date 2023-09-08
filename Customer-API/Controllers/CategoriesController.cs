using Business;
using Business.APIPaging;
using Business.DTOs;
using Business.Filter;
using Business.PageList;
using Microsoft.AspNetCore.Mvc;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private ICategoriesService _categoriesService;
        private IProductsService _productsService;
        public CategoriesController(ICategoriesService categoriesService, IProductsService productsService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CategoryResponse>))]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryResponse> cats = await _categoriesService.GetAllCategories();

            foreach (var category in cats)
            {
                int count = await _productsService.GetProductsCountByCategoryId(category.CategoryId);
                category.ProductsCount = count;
            }

            return Ok(cats);
        }
    }
}
