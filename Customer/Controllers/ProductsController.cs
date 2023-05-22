using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Customer.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            
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

        [Route("[action]")]
        public async Task<IActionResult> Order()
        {
            List<CategoryResponse> categoryResponse = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categoryResponse;

            List<string>? ProductsId = HttpContext.Session.Get<List<string>>("Products");
            List<int>? Quantities = HttpContext.Session.Get<List<int>>("Quantities");
            List<SessionOrder> products;

            if (ProductsId == null || Quantities == null)
            {
                return Redirect("~/");
            }else
            {
                products = await _productsService.GetOrderItems(ProductsId, Quantities);
            }

            ViewBag.Orders = products;

            return View();
        }

        
        [Route("[action]/{ProductId}")]
        public  IActionResult OrderCard(int ProductId, string decreaseByOne, string increaseByOne)
        {
            List<string>? Products = HttpContext.Session.Get<List<string>>("Products");
            List<int>? Quantities = HttpContext.Session.Get<List<int>>("Quantities"); ;


            if (Products == null && Quantities == null)
            {
                Products = new List<string>();
                Quantities = new List<int>();
                Products.Add(ProductId.ToString());
                Quantities.Add(1);

            } else
            {
                int index = Products.FindIndex(temp => temp.Equals(ProductId.ToString()));

                //Sepete Ekle Logic
                if (decreaseByOne == null && increaseByOne == null)
                {
                    
                    if (index == -1)
                    {
                        Products.Add(ProductId.ToString());
                        Quantities.Add(1);
                    }
                    else
                    {
                        Quantities[index]++; ;
                    }
                //Oklarla arttırma ya da azaltma
                }else
                {
                   

                    if (decreaseByOne == null)
                        Quantities[index]++;
                    else if (Quantities[index] > 1)
                        Quantities[index]--;
                    //If quantity is zero remove Product
                    else if(Quantities.Sum() > 1)
                    {
                        Products.RemoveAt(index);
                        Quantities.RemoveAt(index);
                    }else
                    {
                        HttpContext.Session.Clear();
                        return Redirect("~/");

                    }

                }

                
            }
            HttpContext.Session.Set<List<string>>("Products", Products);
            HttpContext.Session.Set<List<int>>("Quantities", Quantities);
            //To Check From _Layout
            HttpContext.Session.SetString("IsNull", "False");

            return Redirect("~/Products/Order");
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
