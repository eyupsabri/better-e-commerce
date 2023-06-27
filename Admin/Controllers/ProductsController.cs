using Business;
using Business.DTOs;
using Business.Filter;
using Business.Helper;
using Business.PageList;
using Castle.Core.Resource;
using Customer.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Dynamic;
using System.Reflection;

namespace Admin.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private ICustomersService _customersService;
        private IOrderItemsService _orderItemsService;

        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, ICustomersService customersService, IOrderItemsService orderItemsService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _customersService = customersService;
            _orderItemsService = orderItemsService;

        }

        [HttpGet, HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Index(ProductFilter productFilter, int pageIndex = 0)
        {

            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            IPagedList<ProductResponse> products;
            
            products = _productsService.GetProducts(productFilter, pageIndex);
            dynamic expendo = new ExpandoObject();
            foreach (PropertyInfo prop in productFilter.GetType().GetProperties())
            {
                          
                if (prop.GetValue(productFilter) != null)
                {
                    
                    products.AddProperty(expendo, prop.Name , prop.GetValue(productFilter));
                }
            }
            
          

            
            products.Url = string.Empty;
            //ViewBag.ProductFilter = productFilter;
            
         

            if (IsAjaxRequest(Request))
                return PartialView("_ProductsPage", products);
           
            return View(products);
          



            //int totalProductsNumber = await _productsService.GetProductsCountByCategoryId(categoryId);

            //int totalPages = TotalPagesCalculator.CalculatingTotalPages(totalProductsNumber);


            //List<ProductResponse> productResponse = await _productsService.GetProductsByPagination(categoryId, 0);
            //SingleProductsPage page = new SingleProductsPage() { Products = productResponse, CurrentPage = 0, TotalPages = totalPages, CategoryId = categoryId };




            //return View(page);
        }
        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> FilteringProducts(ProductFilter filter, int? pageIndex = 0)
        //{

        //}

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> PaginatedProducts(int categoryId, int pageNumber)
        //{

        //    List<ProductResponse> productsResponse = await _productsService.GetProductsByPagination(categoryId, pageNumber);
        //    int totalProductsNumber = await _productsService.GetProductsCountByCategoryId(categoryId);
        //    int totalPages = TotalPagesCalculator.CalculatingTotalPages(totalProductsNumber);
        //    SingleProductsPage page = new SingleProductsPage() { Products = productsResponse, CurrentPage = pageNumber, TotalPages = totalPages, CategoryId = categoryId, CurrentSearchString = null };
        //    return PartialView("_ProductsPage", page);

        //}

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> SearchProductByNameWithPagination(string searchString, int? pageNumber)
        //{
        //    List<ProductResponse> paginatedProducts = await _productsService.GetProductsByNameSearchWithPagination(searchString, pageNumber == null ? 0 : (int)pageNumber);
        //    int totalProductsNumber = await _productsService.GetProductsCountByNameSearch(searchString);
        //    int totalPages = TotalPagesCalculator.CalculatingTotalPages(totalProductsNumber);

        //    if (pageNumber == null)
        //    {
        //        List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
        //        ViewBag.Categories = categoryResponse;
        //        ViewBag.CurrentSearchString = searchString;

        //        SingleProductsPage page = new SingleProductsPage() { Products = paginatedProducts, CurrentPage = pageNumber == null ? 0 : (int)pageNumber, TotalPages = (int)totalPages, CurrentSearchString = searchString, CategoryId = null };
        //        return View("Index", page);
        //    }
        //    else
        //    {
        //        SingleProductsPage page = new SingleProductsPage() { Products = paginatedProducts, CurrentPage = pageNumber == null ? 0 : (int)pageNumber, TotalPages = (int)totalPages, CurrentSearchString = searchString, CategoryId = null };
        //        return PartialView("_ProductsPage", page);
        //    }

        //}

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest product)
        {
            ProductResponse response = await _productsService.UpdateProductById(product);
            return PartialView("_OneProduct", response.ToProductUpdateReq());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RemoveProduct(ProductFilter productFilter, int pageIndex, int ProductIdToBeRemoved, int CategoryIdToBeRemoved)
        {

            await _productsService.DeleteProductById(ProductIdToBeRemoved, CategoryIdToBeRemoved);



            IPagedList<ProductResponse> products = _productsService.GetProducts(productFilter, pageIndex);
            dynamic expendo = new ExpandoObject();
            foreach (PropertyInfo prop in productFilter.GetType().GetProperties())
            {

                if (prop.GetValue(productFilter) != null)
                {

                    products.AddProperty(expendo, prop.Name, prop.GetValue(productFilter));
                }
            }

            return PartialView("_ProductsPage", products);

        }
    }
}
