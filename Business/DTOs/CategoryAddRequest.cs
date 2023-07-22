using Business.ImageHandler;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CategoryAddRequest : IImageHandler
    {
        [Required]
        [StringLength(40)]
        public string CategoryName { get; set; }
        [Required]
        public IFormFile? ImgFile { get; set; }
        public Guid ImageGuid { get; set; }

        public async Task<string> SaveImage(string rootPath)
        {
            if (ImgFile != null)
            {
                var guid = Guid.NewGuid();
                var s = Regex.Escape(Path.Combine("Admin", "wwwroot"));
                var path = Regex.Replace(rootPath, s, "assets");

                var imgPath = Path.Combine(path, "category-img", guid + ".jpg");

                string imgExt = Path.GetExtension(ImgFile.FileName);
                if (imgExt.Equals(".jpg"))
                {
                    using (var uploading = new FileStream(imgPath, FileMode.Create))
                    {
                        ImageGuid = guid;
                        await ImgFile.CopyToAsync(uploading);

                    }
                    return "succesfully added";
                }
                else
                {
                    return "Extention must be jpg";
                }
            }
            return "Image can' t be empty";
        }

        public Category ToCategory()
        {
            return new Category {CategoryName = CategoryName, IsDeleted = false, ImageGuid = ImageGuid };
        }
    }
}
