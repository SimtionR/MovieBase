using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
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

        public async Task DeleteBlobAsync(string blobName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClinet = containerClient.GetBlobClient(blobName);
            await blobClinet.DeleteAsync();
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

        public async Task UploadContentBlobAsync(string content, string fileName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            var bytes = Encoding.UTF8.GetBytes(content);
            await using var memoryStream = new MemoryStream(bytes);
            await blobClient.UploadAsync(memoryStream, new BlobHttpHeaders { ContentType = fileName.GetContetType() });
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContetType() });
        }

        public async Task UploadFileContent(IFormFile file, string containerName, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(file.OpenReadStream(),true);
            

            //await containerClient.UploadAsync()

            
        }
    }
}
