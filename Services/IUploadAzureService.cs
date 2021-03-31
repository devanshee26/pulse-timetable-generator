using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Services
{
    public interface IUploadAzureService
    {
        public Task<MyBlobInfo> GetBlobAsync(string name);
        public Task<IEnumerable<string>> ListBlobAsync();
        public Task UploadFileBlobAsync(string filePath, string fileName);
      
        public Task DeleteBlobAsync(string blobName);
    }
}
