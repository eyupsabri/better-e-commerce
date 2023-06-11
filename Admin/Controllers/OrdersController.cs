using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using Business.Helper;

namespace Admin.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private ICategoriesService _categoriesService;
        private IOrderItemsService _orderItemsService;
        private ICustomersService _customersService;

        public OrdersController(ICategoriesService categoriesService, IOrderItemsService orderItemsService, ICustomersService customersService) {
        
            _categoriesService = categoriesService;
            _orderItemsService = orderItemsService;
            _customersService = customersService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<CustomerResponse> customers = await _customersService.GetPaginatedCustomers(0);
            int customersCount = await _customersService.CustomersCount();
            int totalPages = TotalPagesCalculator.CalculatingTotalPages(customersCount);

            foreach (CustomerResponse customer in customers)
            {
                List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
                customer.Items = orders;
            }
            
            return View(new SingleOrdersPage() { Customers = customers, CurrentPage = 0, CurrentSearchString = null, TotalPages = totalPages});
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PaginatedCustomers(int pageNumber)
        {
            List<CustomerResponse> customers = await _customersService.GetPaginatedCustomers(pageNumber);
            int customersCount = await _customersService.CustomersCount();
            int totalPages = TotalPagesCalculator.CalculatingTotalPages(customersCount);

            foreach (CustomerResponse customer in customers)
            {
                List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
                customer.Items = orders;
            }

            return PartialView("_OrdersPage", new SingleOrdersPage() { Customers = customers, CurrentPage = pageNumber, CurrentSearchString = null, TotalPages = totalPages });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PaginatedCustomersByNameSearch(int? pageNumber, string searchString)
        {
            List<CustomerResponse> customers = await _customersService.GetCustomersByNameSearchPaginated(searchString, pageNumber == null ? 0 : pageNumber.Value);
            int customersCount = await _customersService.GetCustomersCountByNameSearch(searchString);
            int totalPages = TotalPagesCalculator.CalculatingTotalPages(customersCount);

            if (customers.Count == 0)
            {
                return Redirect("Home/Index");
            }else if(pageNumber == null)
            {
                foreach (CustomerResponse customer in customers)
                {
                    List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
                    customer.Items = orders;
                }
                List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
                ViewBag.Categories = categoryResponse;
                return View("Index", new SingleOrdersPage() { Customers = customers, CurrentPage = 0, CurrentSearchString = searchString, TotalPages = totalPages });
            }
            else
            {
                foreach (CustomerResponse customer in customers)
                {
                    List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
                    customer.Items = orders;
                }
                return PartialView("_OrdersPage", new SingleOrdersPage() { Customers = customers, CurrentPage = pageNumber.Value, CurrentSearchString = searchString, TotalPages = totalPages });
            }
        }

    }
}
