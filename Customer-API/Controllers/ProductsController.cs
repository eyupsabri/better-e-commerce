using Business;
using Business.APIPaging;
using Business.DTOs;
using Business.Filter;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IWebHostEnvironment _webhost;


        public ProductsController(IProductsService productsService, IWebHostEnvironment webHost)
        {
            _productsService = productsService;
            _webhost = webHost;
        }

        [HttpGet]
        [Authorize]
        [Route("products")]
        [ProducesResponseType(200, Type = typeof(Paging<ProductResponse>))]
        public  IActionResult GetProductsByCategoryId([FromQuery] int categoryId, [FromQuery] int pageIndex = 0)
        {
            ProductFilter filter = new ProductFilter() { CategoryId = categoryId, sortAsc = true, sortBy= "productName" };
            var myList = _productsService.GetProducts(filter, pageIndex);


            return Ok(new Paging<ProductResponse>(myList));
        }






        [HttpPost]
        
        [Route("update")]
        [ProducesResponseType(200, Type = typeof(Paging<ProductResponse>))]
        
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateRequest product)
        {
            var productResponse = await _productsService.GetProductByProductId(product.ProductId);
            var rootPath = _webhost.WebRootPath;
            string response = await product.SaveImage(rootPath);

            switch (response)
            {
                case "succesfully added":
                    ProductResponse succesfulResponse = await _productsService.UpdateProductById(product);
                    return Ok(succesfulResponse);
                case "Extention must be jpg":
                    return Ok("extention wrong");
                default:
                    var oldGuid = productResponse.ImageGuid;
                    product.ImageGuid = oldGuid;
                    ProductResponse updatedProduct = await _productsService.UpdateProductById(product);
                    return Ok(updatedProduct);

            }


        }


    }
}
