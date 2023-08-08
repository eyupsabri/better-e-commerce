using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("[controller]")]
    public class CustomersController : Controller
    {

        ICustomersService CustomersService;
        ICategoriesService CategoriesService;
        IProductsService ProductsService;

        public CustomersController(ICustomersService customersService, ICategoriesService categoriesService)
        {
            this.CustomersService = customersService;
            this.CategoriesService = categoriesService;

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            List<SessionOrder>? orders = HttpContext.Session.Get<List<SessionOrder>>("Products");
            if(orders == null)
            {
                return Redirect("~/");
            }

            List<CategoryResponse> categoryResponse = await CategoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> OrderCompleted(CustomerAddRequest customerAddReq)
        {
            //List<CategoryResponse> categoryResponse = await CategoriesService.GetAllCategories();
            //ViewBag.Categories = categoryResponse;
            

            List<SessionOrder> orders = HttpContext.Session.Get<List<SessionOrder>>("Products");
            

            CustomerResponse customer = await CustomersService.AddCustomerWithOrder(customerAddReq, orders);

            HttpContext.Session.Clear();
           
            return PartialView("_OrderCompleted", customer);
        }
    }
}
