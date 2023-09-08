using Business;
using Business.APIPaging;
using Business.DTOs;
using Business.Filter;
using Business.PageList;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private ICustomersService _customersService;

        public SearchController(IProductsService productsService, ICategoriesService categoriesService, ICustomersService customersService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _customersService = customersService;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Paging<ProductResponse>))]
        public IActionResult GetSearch(ProductFilter productFilter, int pageIndex = 0)
        {
            IPagedList<ProductResponse> products = _productsService.GetProducts(productFilter, pageIndex);

            
            return Ok(new Paging<ProductResponse>(products));
        }

    }
}
