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
    public class CategoryAddRequest
    {
        [Required]
        [StringLength(40)]
        public string CategoryName { get; set; }
        [Required]
        public IFormFile? ImgFile { get; set; }
        public Guid ImageGuid { get; set; }

        public Category ToCategory()
        {
            return new Category {CategoryName = CategoryName, IsDeleted = false, ImageGuid = ImageGuid };
        }
    }
}
