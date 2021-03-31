using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Pulse.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulse.Services
{
    public class UploadAzureService : IUploadAzureService
    {
        private readonly BlobServiceClient blobServiceClient;

        public UploadAzureService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }
        public async Task DeleteBlobAsync(string blobName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("pulse-resources-container");
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<MyBlobInfo> GetBlobAsync(string name)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("pulse-resources-container");
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownloadInfo = await blobClient.DownloadAsync();
            return new MyBlobInfo(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobAsync()
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("pulse-resources-container");
            var items = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }
            return items;
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("pulse-resources-container");
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType()});

        }
       
    }
}
