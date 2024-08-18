using Business;
using Business.DTOs;
using Business.Filter;
using Business.Helper;
using Business.PageList;
using Castle.Core.Resource;

using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Admin.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private ICustomersService _customersService;
        //private IOrderItemsService _orderItemsService;
        private ICloudStorage _cloudStorage;
        private readonly IWebHostEnvironment _webhost;
        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, ICustomersService customersService, IWebHostEnvironment webhost, ICloudStorage cloudStorage)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _customersService = customersService;
            //_orderItemsService = orderItemsService;
            _webhost = webhost;
            _cloudStorage = cloudStorage;
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

                    products.AddProperty(expendo, prop.Name, prop.GetValue(productFilter));
                }
            }




            products.Url = string.Empty;
            //ViewBag.ProductFilter = productFilter;



            if (IsAjaxRequest(Request))
                return PartialView("_ProductsPage", products);

            return View(products);

        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest product)
        {
            var productResponse = await _productsService.GetProductByProductId(product.ProductId);
            var rootPath = _webhost.WebRootPath;
            //string response = await product.SaveImage(rootPath);
            var name = Guid.NewGuid();
            string response = await _cloudStorage.UploadProImgAsync(product.ImgFile, name.ToString().ToUpper());

            switch (response)
            {
                case "succesfully added":
                    product.ImageGuid = name;
                    ProductResponse succesfulResponse = await _productsService.UpdateProductById(product);
                    return PartialView("_OneProduct", succesfulResponse.ToProductUpdateReq());
                case "Extention must be jpg":
                    return Json(response);
                default:
                    var oldGuid = productResponse.ImageGuid;
                    product.ImageGuid = oldGuid;
                    ProductResponse updatedProduct = await _productsService.UpdateProductById(product);
                    return PartialView("_OneProduct", updatedProduct.ToProductUpdateReq());

            }


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

        [HttpGet, HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct(ProductAddRequest product)
        {
            string s = string.Empty;

            if (IsAjaxRequest(Request))
            {
                var rootPath = _webhost.WebRootPath;
                //string response =await product.SaveImage(rootPath);
                var name = Guid.NewGuid();
                string response = await _cloudStorage.UploadProImgAsync(product.ImgFile, name.ToString().ToUpper());

                switch (response)
                {
                    //default:
                    //    return list;
                    case "succesfully added":
                        product.ImageGuid = name;
                        await _productsService.AddNewProduct(product);
                        break;
                    case "Extention must be jpg":
                        break;
                    case "Image can' t be empty":
                        break;

                }

                return Json(response);

                //if (product.ImgFile != null)
                //{
                //    var guid = Guid.NewGuid();
                //    var s = Regex.Escape(Path.Combine("Admin", "wwwroot"));
                //    var path = Regex.Replace(_webhost.WebRootPath, s, "assets");

                //    var imgPath = Path.Combine(path, "products", guid + ".jpg");

                //    string imgExt = Path.GetExtension(product.ImgFile.FileName);
                //    if (imgExt.Equals(".jpg"))
                //    {
                //        using (var uploading = new FileStream(imgPath, FileMode.Create))
                //        {
                //            product.ImageGuid = guid;
                //            await product.ImgFile.CopyToAsync(uploading);
                //            await _productsService.AddNewProduct(product);
                //        }
                //        return Json("succesfully added");
                //    }
                //    else
                //    {                      
                //        return Json("Extention must be jpg");
                //    }
                //}
            }

            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            return View();
        }
    }
}
