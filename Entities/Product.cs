using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(40)]
        public string ProductName { get; set; }   

        public double ProductPrice { get; set;}

        [StringLength(200)]
        public string ProductDescription { get; set;}

        //Foreign key for Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
