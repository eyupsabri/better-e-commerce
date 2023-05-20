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
        public int CategoryId;
        public string CategoryName;
    }

    public static class CategoryExtensions
    {
        public static CategoryResponse ToCategoryResponse(this Category category)
        {
            return new CategoryResponse() { CategoryId = category.CategoryId, CategoryName = category.CategoryName };
        }
    }
}