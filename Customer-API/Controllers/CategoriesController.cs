using Business;
using Business.APIPaging;
using Business.DTOs;
using Business.Filter;
using Business.PageList;
using Customer_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Internal;
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

        [Authorize]
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


        [Authorize]
        [HttpGet]
        [Route("dummycategories")]
        [ProducesResponseType(200, Type = typeof(List<DummyCat>))]
        public  ActionResult GetDummyCategories()
        {
            
            DummyCat dum1 = new DummyCat() { Id = 1, Title = "birinci"};
            DummyCat dum2 = new DummyCat() { Id = 2, Title = "ikinci" };
            DummyCat dum3 = new DummyCat() { Id = 3, Title = "ucuncu" };
          

            DummyCat dum4 = new DummyCat() { Id = 4, Title = "Birincinin 1", ParentMenuItemId = 1, Url = "cekoslavakya" };
            DummyCat dum5 = new DummyCat() { Id = 5, Title = "ikincinin 1", ParentMenuItemId = 2, Url = "pakistan" };
            DummyCat dum6 = new DummyCat() { Id = 6, Title = "Ucuncunun 1", ParentMenuItemId = 3, Url = "usa" };

            DummyCat dum7 = new DummyCat() { Id = 7, Title = "Birincinin 2", ParentMenuItemId = 1, Url = "germany" };
            DummyCat dum8 = new DummyCat() { Id = 8, Title = "Birincinin 3", ParentMenuItemId = 1, Url = "india" };
            DummyCat dum9 = new DummyCat() { Id = 9, Title = "Birincinin 4", ParentMenuItemId = 1, Url = "france" };

            DummyCat dum10 = new DummyCat() { Id = 10, Title = "ikincinin 2", ParentMenuItemId = 2, Url = "egypt" };
            DummyCat dum11 = new DummyCat() { Id = 11, Title = "ucuncunun 2", ParentMenuItemId = 3, Url = "italy" };
            DummyCat dum12 = new DummyCat() { Id = 12, Title = "ikincinin 3", ParentMenuItemId = 2, Url = "finland" };
            List<DummyCat> cats = new List<DummyCat>() { dum1, dum2, dum3, dum4, dum5, dum6, dum7, dum8, dum9, dum10, dum11, dum12};


            return Ok(cats);
        }

    }
}
