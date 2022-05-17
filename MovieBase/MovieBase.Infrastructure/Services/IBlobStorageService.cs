using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Services
{
    public interface IBlobStorageService
    {
        Task<BlobInfo> GetBlobAsync(string name, string containerName);
        Task<IEnumerable<string>> ListBlobMoviesAsync(string containerName);
        Task UploadFileBlobAsync(string filePath, string fileName, string containerName);
        Task UploadContentBlobAsync(string content, string fileName, string containerName);
        Task DeleteBlobAsync(string blobName, string containerName);
        Task UploadFileContent(IFormFile file, string containerName, string fileName);
    }
}
