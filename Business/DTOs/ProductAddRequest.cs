using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ProductAddRequest
    {
       
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductDescription { get; set; }

        [Required]
        public int? CategoryId { get; set; }       
        public Guid ImageGuid { get; set; } 
        [Required]
        public IFormFile ImgFile { get; set; }

        public Product ToProduct()
        {
            return new Product() { IsDeleted = false, ProductName = ProductName, ImageGuid = ImageGuid, ProductPrice = Decimal.ToDouble(ProductPrice), ProductDescription = ProductDescription, CategoryId = CategoryId == null ? 0 : CategoryId.Value };
        }

    }


}
