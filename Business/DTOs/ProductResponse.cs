using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ProductUpdateRequest ToProductUpdateReq()
        {
            return new ProductUpdateRequest() { ProductDescription = ProductDescription, ProductId = ProductId, ProductName = ProductName, ProductPrice = (decimal)ProductPrice, CategoryId = CategoryId };
        }
    }

    public static class ProductExtentions
    {
        public static ProductResponse ToProductResponse(this Product prod)
        {
            return new ProductResponse() { CategoryId = prod.CategoryId, ProductDescription = prod.ProductDescription, 
                ProductName = prod.ProductName, ProductPrice = prod.ProductPrice, ProductId = prod.ProductId, CategoryName = prod.Category.CategoryName };
        }
    }
}
