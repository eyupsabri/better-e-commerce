﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public bool IsDeleted { get; set; }
        public int ProductId { get; set; }
        [Required]
        public Guid ImageGuid { get; set; }

        [StringLength(40)]
        public string ProductName { get; set; }   

        public double ProductPrice { get; set;}

        [StringLength(200)]
        public string ProductDescription { get; set;}

        //Foreign key ekleyerek dependent yapıyorsun. Can't exist without a Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
