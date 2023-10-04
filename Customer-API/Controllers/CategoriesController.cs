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
            List<DummyCat> cats = new List<DummyCat>();
            DummyCat dum1 = new DummyCat() { Id = 1, Title = "birinci"};
            DummyCat dum2 = new DummyCat() { Id = 2, Title = "ikinci" };
            DummyCat dum3 = new DummyCat() { Id = 3, Title = "ucuncu" };
            DummyCat dum22 = new DummyCat() { Id = 22, Title = "Birincinin 10", ParentMenuItemId = 1, Url = "cekoslavakya" };

            DummyCat dum4 = new DummyCat() { Id = 4, Title = "Birincinin 1", ParentMenuItemId = 1, Url = "cekoslavakya" };
            DummyCat dum5 = new DummyCat() { Id = 5, Title = "ikincinin 1", ParentMenuItemId = 2, Url = "cekoslavakya" };
            DummyCat dum6 = new DummyCat() { Id = 6, Title = "Ucuncunun 1", ParentMenuItemId = 3, Url = "cekoslavakya" };

            DummyCat dum7 = new DummyCat() { Id = 7, Title = "Birincinin 2", ParentMenuItemId = 1, Url = "cekoslavakya" };
            DummyCat dum8 = new DummyCat() { Id = 8, Title = "Birincinin 3", ParentMenuItemId = 1, Url = "cekoslavakya" };
            DummyCat dum9 = new DummyCat() { Id = 9, Title = "Birincinin 4", ParentMenuItemId = 1, Url = "cekoslavakya" };

            DummyCat dum10 = new DummyCat() { Id = 10, Title = "ikincinin 2", ParentMenuItemId = 2, Url = "cekoslavakya" };
            DummyCat dum11 = new DummyCat() { Id = 11, Title = "ucuncunun 2", ParentMenuItemId = 3, Url = "cekoslavakya" };
            DummyCat dum12 = new DummyCat() { Id = 12, Title = "ikincinin 3", ParentMenuItemId = 2, Url = "cekoslavakya" };


            DummyCat dum13 = new DummyCat() { Id = 13, Title = "Birincinin 1", ParentMenuItemId = 1, Url = "cekoslavakya" };
            DummyCat dum14 = new DummyCat() { Id = 14, Title = "ikincinin 1", ParentMenuItemId = 2, Url = "cekoslavakya" };
            DummyCat dum15 = new DummyCat() { Id = 15, Title = "Ucuncunun 1", ParentMenuItemId = 3, Url = "cekoslavakya" };

            DummyCat dum16 = new DummyCat() { Id = 16, Title = "Birincinin 2", ParentMenuItemId = 1, Url = "cekoslavakya" };
            DummyCat dum17 = new DummyCat() { Id = 17, Title = "Birincinin 3", ParentMenuItemId = 1, Url = "cekoslavakya" };
            DummyCat dum18 = new DummyCat() { Id = 18, Title = "Birincinin 4", ParentMenuItemId = 1, Url = "cekoslavakya" };

            DummyCat dum19 = new DummyCat() { Id = 19, Title = "ikincinin 2", ParentMenuItemId = 2, Url = "cekoslavakya" };
            DummyCat dum20 = new DummyCat() { Id = 20, Title = "ucuncunun 2", ParentMenuItemId = 3, Url = "cekoslavakya" };
            DummyCat dum21 = new DummyCat() { Id = 21, Title = "ikincinin 3", ParentMenuItemId = 2, Url = "cekoslavakya" };




            cats.Add(dum1);
            cats.Add(dum2);
            cats.Add(dum3);
            cats.Add(dum4);
            cats.Add(dum5);
            cats.Add(dum6);
            cats.Add(dum7);
            cats.Add(dum8);
            cats.Add(dum9);
            cats.Add(dum10);
            cats.Add(dum11);
            cats.Add(dum12);
            cats.Add(dum13);
            cats.Add(dum14);
            cats.Add(dum15);
            cats.Add(dum16);
            cats.Add(dum17);
            cats.Add(dum18);
            cats.Add(dum19);
            cats.Add(dum20);
            cats.Add(dum21);
            cats.Add(dum22);

            return Ok(cats);
        }

    }
}
