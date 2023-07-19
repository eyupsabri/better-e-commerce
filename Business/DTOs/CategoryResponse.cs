using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ProductsCount { get; set; }
        public Guid ImageGuid { get; set; }
    }

    public static class CategoryExtensions
    {
        public static CategoryResponse ToCategoryResponse(this Category category)
        {
            return new CategoryResponse() { CategoryId = category.CategoryId, CategoryName = category.CategoryName, ImageGuid = category.ImageGuid };
        }
    }
}