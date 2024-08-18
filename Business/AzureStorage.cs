using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AzureStorage : ICloudStorage
    {
        private IStorageConnectionFactory _connectionFactory;
        public AzureStorage(IStorageConnectionFactory storageConnectionFactory)
        {
            _connectionFactory = storageConnectionFactory;
        }


        public async Task<string> UploadCatImgAsync(IFormFile file, string name)
        {
            try
            {
                if (file != null)
                {
                    string imgExt = Path.GetExtension(file.FileName);
                    if (imgExt.Equals(".jpg"))
                    {
                        var blobContainer = await _connectionFactory.GetCategoryContainer();
                        BlobClient blob = blobContainer.GetBlobClient(name + ".jpg");
                        using (var stream = file.OpenReadStream())
                        {
                            await blob.UploadAsync(stream);
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
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }
        public async Task<string> UploadProImgAsync(IFormFile file, string name)
        {
            try
            {
                if (file != null)
                {
                    string imgExt = Path.GetExtension(file.FileName);
                    if (imgExt.Equals(".jpg"))
                    {
                        var blobContainer = await _connectionFactory.GetProductContainer();
                        BlobClient blob = blobContainer.GetBlobClient(name + ".jpg");
                        using (var stream = file.OpenReadStream())
                        {
                            await blob.UploadAsync(stream);
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
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }
    }
}
