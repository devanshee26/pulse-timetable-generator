using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pulse.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Controllers
{
   [AllowAnonymous]
   [Route("blobs")]
    public class ResourcesController : Controller
    {
        private readonly IUploadAzureService service;

        public ResourcesController(IUploadAzureService service)
        {
            this.service = service;
        }
        [HttpGet("{BlobName}")]
        public async Task<IActionResult> ViewResources(string blobName)
        {
            var data = await service.GetBlobAsync(blobName);
            return File(data.content, data.contentType);
          //  return View();
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListBlobs()
        {
            return Ok(await service.ListBlobAsync());
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileRequest request)
        {
            await service.UploadFileBlobAsync(request.FilePath, request.FileName);
            return Ok();
        }
        
        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            await service.DeleteBlobAsync(blobName);
            return Ok();
        }


    }
}
