using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;

using Business.Helper;
using Business.PageList;
using Business.Filter;
using Entities;
using System.Dynamic;
using System.Reflection;

namespace Admin.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private ICategoriesService _categoriesService;
        private IOrderItemsService _orderItemsService;
        private ICustomersService _customersService;
        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
        public OrdersController(ICategoriesService categoriesService, IOrderItemsService orderItemsService, ICustomersService customersService)
        {

            _categoriesService = categoriesService;
            _orderItemsService = orderItemsService;
            _customersService = customersService;
        }

        [HttpGet, HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Index(CustomerFilter filter, int pageNumber = 0)
        {
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;
            

            var customers =  _customersService.GetFilteredCustomers(filter, pageNumber);

            dynamic expendo = new ExpandoObject();
            foreach (PropertyInfo prop in filter.GetType().GetProperties())
            {
                if (prop.GetValue(filter) != null)
                {

                    customers.AddProperty(expendo, prop.Name, prop.GetValue(filter));
                }
            }

            customers.Url = Url.Action("Index");
            

            foreach (CustomerResponse customer in customers)
            {
                List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
                customer.Items = orders;
            }

            if (IsAjaxRequest(Request))
                return PartialView("_OrdersPage", customers);

            return View(customers);
        }


        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> PaginatedCustomers(int pageNumber)
        //{
        //    List<CustomerResponse> customers = await _customersService.GetPaginatedCustomers(pageNumber);
        //    int customersCount = await _customersService.CustomersCount();
        //    int totalPages = TotalPagesCalculator.CalculatingTotalPages(customersCount);

        //    foreach (CustomerResponse customer in customers)
        //    {
        //        List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
        //        customer.Items = orders;
        //    }

        //    return PartialView("_OrdersPage", new SingleOrdersPage() { Customers = customers, CurrentPage = pageNumber, CurrentSearchString = null, TotalPages = totalPages });
        //}

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> PaginatedCustomersByNameSearch(int? pageNumber, string searchString)
        //{
        //    IPagedList<CustomerResponse> customers = await _customersService.GetCustomers(searchString, pageNumber == null ? 0 : pageNumber.Value);
        //    //int customersCount = await _customersService.GetCustomersCountByNameSearch(searchString);
        //    //int totalPages = TotalPagesCalculator.CalculatingTotalPages(customersCount);

        //    //if (customers.Count == 0)
        //    //{
        //    //    return Redirect("~/Home");
        //    if (pageNumber == null)
        //    {
        //        foreach (CustomerResponse customer in customers)
        //        {
        //            List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
        //            customer.Items = orders;
        //        }
        //        List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
        //        ViewBag.Categories = categoryResponse;
        //        ViewBag.CurrentSearchString = searchString;
        //        return View("Index", new SingleOrdersPage() { Customers = customers, CurrentPage = 0, CurrentSearchString = searchString, TotalPages = totalPages });
        //    }
        //    else
        //    {
        //        foreach (CustomerResponse customer in customers)
        //        {
        //            List<SessionOrder> orders = await _orderItemsService.GetAllOrderItemsByOrderId(customer.OrderId);
        //            customer.Items = orders;
        //        }
        //        return PartialView("_OrdersPage", new SingleOrdersPage() { Customers = customers, CurrentPage = pageNumber.Value, CurrentSearchString = searchString, TotalPages = totalPages });
        //    }
        //}

    }
}
