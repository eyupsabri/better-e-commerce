using Business.DTOs;

namespace Customer.Models
{
    public class SingleProductsPage
    {
        public List<ProductResponse> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; } 
    }
}
