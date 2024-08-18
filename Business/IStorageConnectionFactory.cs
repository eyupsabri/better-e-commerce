using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IStorageConnectionFactory
    {
        Task<BlobContainerClient> GetCategoryContainer();
        Task<BlobContainerClient> GetProductContainer();
    }
}
