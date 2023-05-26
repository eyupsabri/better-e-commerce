using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Admin.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private ICustomersService _customersService;
        private IOrderItemsService _orderItemsService;
        

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, ICustomersService customersService, IOrderItemsService orderItemsService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _customersService = customersService;
            _orderItemsService = orderItemsService;
            
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> ProductsByCategoryId(int id)
        {
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<ProductResponse> productResponse = await _productsService.GetAllProductsByCategoryId(id);
            ViewBag.Products = productResponse;

            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllOrders()
        {
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<CustomerResponse> customers = await _customersService.GetAllCustomers();          
            Dictionary<CustomerResponse, List<SessionOrder>> myDictionary = new Dictionary<CustomerResponse, List<SessionOrder>>();

            foreach (CustomerResponse customer in customers)
            {
                List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
                myDictionary[customer] = orders;
            }
            ViewBag.myDictionary = myDictionary;
            return View();
        }
    }
}
