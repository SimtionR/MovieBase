using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using MovieBase.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
           
        }

        public Task DeleteBlobAsync(string blobName, string containerName)
        {
            throw new NotImplementedException();
        }

        public async Task<BlobInfo> GetBlobAsync(string name, string containerName)
        {
       

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            var blobDownnloadInfo = await blobClient.DownloadAsync();

           

            var blob = new BlobInfo(blobDownnloadInfo.Value.Content, blobDownnloadInfo.Value.Details.ContentType);

            return blob;
        }

        public async Task<IEnumerable<string>> ListBlobMoviesAsync(string containerName)
        {
            var containerCliet = _blobServiceClient.GetBlobContainerClient(containerName);
            var items = new List<string>();

            await foreach(var blobItem in containerCliet.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }

            return items;
        }

        public Task UploadContentBlobAsync(string content, string fileName, string containerName)
        {
            throw new NotImplementedException();
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContetType() });
        }
    }
}
