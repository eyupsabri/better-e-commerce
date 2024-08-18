using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICloudStorage
    {

        Task<string> UploadCatImgAsync(IFormFile file, string name);
        Task<string> UploadProImgAsync(IFormFile file, string name);

    }
}
