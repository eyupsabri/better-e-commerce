using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ImageHandler
{
    public interface IImageHandler
    {
        public Task<string> SaveImage(string rootPath); 
    }
}
