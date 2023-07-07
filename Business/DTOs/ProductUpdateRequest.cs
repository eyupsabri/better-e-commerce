using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ProductUpdateRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductDescription { get; set; }

        public int? CategoryId { get; set; }
        public Guid ImageGuid { get; set; }

        public Product ToProduct()
        {
            return new Product() { ProductId = ProductId, ProductName = ProductName, ProductPrice = Decimal.ToDouble(ProductPrice), ProductDescription = ProductDescription, ImageGuid = ImageGuid };
        }

    }
}

