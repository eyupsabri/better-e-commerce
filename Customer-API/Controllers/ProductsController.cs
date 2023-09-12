using Business;
using Business.APIPaging;
using Business.DTOs;
using Business.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;

       
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Paging<ProductResponse>))]
        public  IActionResult GetProductsByCategoryId([FromQuery] int categoryId, [FromQuery] int pageIndex = 0)
        {
            ProductFilter filter = new ProductFilter() { CategoryId = categoryId, sortAsc = true, sortBy= "productName" };
            var myList = _productsService.GetProducts(filter, pageIndex);


            return Ok(new Paging<ProductResponse>(myList));
        }
    }
}
