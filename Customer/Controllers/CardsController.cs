using Business;
using Business.DTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("[controller]")]
    public class CardsController : Controller
    {
        private IProductsService _productsService;

        public ICategoriesService CategoriesService { get; }

        public CardsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            CategoriesService = categoriesService;
        }


        [HttpGet,Route("index")]
        public async Task<IActionResult> Index()
        {
            List<SessionOrder>? products = HttpContext.Session.Get<List<SessionOrder>>("Products");
            if (products == null)
            {
                return Redirect("~/");
            }
            List<CategoryResponse> categoryResponse = await CategoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;
            
            return View(products);
        }


        [HttpGet]
        [Route("AddToCard/{ProductId}")]
        public async Task<IActionResult> AddToCard(int ProductId)
        {
            List<SessionOrder>? products = HttpContext.Session.Get<List<SessionOrder>>("Products");
            SessionOrder orderCardItem = await _productsService.GetOneOrderByProductId(ProductId, 1);

            if (products == null)
            {             
                products = new List<SessionOrder>();
                products.Add(orderCardItem);
                HttpContext.Session.Set<List<SessionOrder>>("Products", products);
                HttpContext.Session.Set<string>("IsNull", "false");
            }
            else
            {

                int index = products.FindIndex(temp => temp.Product.ProductId == ProductId);
                if (index == -1)
                {
                    products.Add(orderCardItem);
                    HttpContext.Session.Set<List<SessionOrder>>("Products", products);
                }else
                {
                    products[index].Quantity++;
                    HttpContext.Session.Set<List<SessionOrder>>("Products", products);

                }
            }

            return RedirectToAction("Index");

        }


        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(int productId, bool decrease)
        {
            List<SessionOrder> products = HttpContext.Session.Get<List<SessionOrder>>("Products");
            int index = products.FindIndex(temp => temp.Product.ProductId == productId);
            if (!decrease)
            {
                products[index].Quantity++;
                HttpContext.Session.Set<List<SessionOrder>>("Products", products);

            }
            else
            {
                products[index].Quantity--;
                if (products[index].Quantity == 0)
                {
                    products.RemoveAt(index);
                }

                if (products.Count == 0)
                {
                    HttpContext.Session.Clear();
                    return Json(null);
                }
                else if(products.Count > 0) 
                {
                    HttpContext.Session.Set<List<SessionOrder>>("Products", products);
                }      
                
            }
            return PartialView("_OrderCard", products);
        }
    }
}
