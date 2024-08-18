using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StorageConnectionFactory : IStorageConnectionFactory
    {

        private BlobContainerClient _blobContainerCat;
        private BlobContainerClient _blobContainerPro;
        private readonly CloudStorageOptionsDTO _cloudStorageOptionsDTO;

        public StorageConnectionFactory(CloudStorageOptionsDTO storageOptions)
        {
            _cloudStorageOptionsDTO = storageOptions;
        }
        public async Task<BlobContainerClient> GetCategoryContainer()
        {
            if (_blobContainerCat != null)
            {
                return _blobContainerCat;
            }
            BlobServiceClient blobServiceClient = new BlobServiceClient(_cloudStorageOptionsDTO.ConnectionString);

            _blobContainerCat = blobServiceClient.GetBlobContainerClient(_cloudStorageOptionsDTO.CategoryImgContainer);

            await _blobContainerCat.CreateIfNotExistsAsync(PublicAccessType.Blob);
            return _blobContainerCat;
        }
        public async Task<BlobContainerClient> GetProductContainer()
        {
            if (_blobContainerPro != null)
            {
                return _blobContainerPro;
            }
            BlobServiceClient blobServiceClient = new BlobServiceClient(_cloudStorageOptionsDTO.ConnectionString);

            _blobContainerPro = blobServiceClient.GetBlobContainerClient(_cloudStorageOptionsDTO.ProductImgContainer);

            await _blobContainerPro.CreateIfNotExistsAsync(PublicAccessType.Blob);
            return _blobContainerPro;
        }
    }
}
