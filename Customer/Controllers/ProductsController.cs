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
            int QuantitiesSum;
            List<SessionOrder> products;

            if (ProductsId == null || Quantities == null)
            {
                return Redirect("~/");
            }else
            {
                products = await _productsService.GetOrderItems(ProductsId, Quantities);
                QuantitiesSum = Quantities.Sum();
            }

            ViewBag.Orders = products;
            ViewBag.QuantitiesSum = QuantitiesSum;

            return View();
        }

        
        [Route("[action]/{ProductId}")]
        public async Task<IActionResult> OrderCard(int ProductId, string decreaseByOne, string increaseByOne)
        {
            List<string>? Products = HttpContext.Session.Get<List<string>>("Products");
            List<int>? Quantities = HttpContext.Session.Get<List<int>>("Quantities");

            //Sıfırdan sepete ekleme
            if (Products == null && Quantities == null)
            {
                Products = new List<string>();
                Quantities = new List<int>();
                Products.Add(ProductId.ToString());
                Quantities.Add(1);

                HttpContext.Session.Set<List<string>>("Products", Products);
                HttpContext.Session.Set<List<int>>("Quantities", Quantities);
                //To Check From _Layout
                HttpContext.Session.SetString("IsNull", "False");
                return Redirect("~/Products/Order");

            } else
            {
                int index = Products.FindIndex(temp => temp.Equals(ProductId.ToString()));

                //Products' dan sepete ekleme
                if (decreaseByOne == null && increaseByOne == null)
                {
                    
                    if (index == -1)
                    {
                        Products.Add(ProductId.ToString());
                        Quantities.Add(1);
                    }
                    else
                    {
                        Quantities[index]++;
                    }
                    HttpContext.Session.Set<List<string>>("Products", Products);
                    HttpContext.Session.Set<List<int>>("Quantities", Quantities);
                    HttpContext.Session.SetString("IsNull", "False");

                    return Redirect("~/Products/Order");
                    
                }
                //Oklarla arttırma ya da azaltma
                else
                {
                    //Arttırma
                    if (decreaseByOne == null)
                    {
                        Quantities[index]++;
                        List<SessionOrder> orderCardItem = await _productsService.GetOrderItems(Products, Quantities);

                        double totalSum = 0;
                        double indivualSum = 0;
                        foreach (SessionOrder orderItem in orderCardItem)
                        {
                            totalSum = totalSum + orderItem.Quantity * orderItem.Product.ProductPrice;
                            if(orderItem.Product.ProductId == ProductId)
                            {
                                indivualSum = orderItem.Product.ProductPrice * Quantities[index];
                            }
                        }
                        Dictionary<string, string> orderJson = new Dictionary<string, string>();
                        orderJson.Add("totalSum", totalSum.ToString());
                        orderJson.Add("individualSum", indivualSum.ToString());
                        orderJson.Add("quantity", Quantities[index].ToString());

                        HttpContext.Session.Set<List<string>>("Products", Products);
                        HttpContext.Session.Set<List<int>>("Quantities", Quantities);

                        HttpContext.Session.SetString("IsNull", "False");

                        return Json(orderJson);
                    }
                    //Azaltma, 
                       //Aynı üründen birden fazla 
                    else if (Quantities[index] > 1)
                    {
                        Quantities[index]--;

                        List<SessionOrder> orderCardItem = await _productsService.GetOrderItems(Products, Quantities);

                        double totalSum = 0;
                        double indivualSum = 0;
                        foreach (SessionOrder orderItem in orderCardItem)
                        {
                            totalSum = totalSum + orderItem.Quantity * orderItem.Product.ProductPrice;
                            if (orderItem.Product.ProductId == ProductId)
                            {
                                indivualSum = orderItem.Product.ProductPrice * Quantities[index];
                            }
                        }
                        Dictionary<string, string> orderJson = new Dictionary<string, string>();
                        orderJson.Add("totalSum", totalSum.ToString());
                        orderJson.Add("individualSum", indivualSum.ToString());
                        orderJson.Add("quantity", Quantities[index].ToString());

                        HttpContext.Session.Set<List<string>>("Products", Products);
                        HttpContext.Session.Set<List<int>>("Quantities", Quantities);
                        HttpContext.Session.SetString("IsNull", "False");
                        
                        return Json(orderJson);
                    }

                    //If quantity is zero, but there are other items in Card, remove Product
                    else if (Quantities.Sum() > 1)
                    {
                        Products.RemoveAt(index);
                        Quantities.RemoveAt(index);
                        HttpContext.Session.Set<List<string>>("Products", Products);
                        HttpContext.Session.Set<List<int>>("Quantities", Quantities);
                        HttpContext.Session.SetString("IsNull", "False");

                        return Json(new Dictionary<string, string>() { { "notEmpty", "notEmpty" } });
                    }
                    else
                    {
                        HttpContext.Session.Clear();
                        //return Redirect("~/");

                        return Redirect("~/Products/Order");

                    }

                }

            }
          
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
