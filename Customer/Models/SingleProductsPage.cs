﻿using Business.DTOs;

namespace Customer.Models
{
    public class SingleProductsPage : PagingModel
    {
        public List<ProductResponse>? Products { get; set; }
        //public int CurrentPage { get; set; }
        //public int TotalPages { get; set; }
        public int? CategoryId { get; set; }
        public string? CurrentSearchString { get; set; }
        public string? CategoryName { get; set; }
    }
}
