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
   //[Route("blobs")]
    public class ResourcesController : Controller
    {
        private readonly IUploadAzureService service;

        public ResourcesController(IUploadAzureService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ViewResources(string blobName)
        {
            var data = await service.GetBlobAsync(blobName);
            return File(data.content, data.contentType);
          //  return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListResources()
        {
            IEnumerable<string> resources = await service.ListBlobAsync();
            return View(resources);
        }
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadFileRequest request)
        {

            await service.UploadFileBlobAsync(request.FilePath, request.FileName);
            return RedirectToAction("ListResources", "Resources");
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            await service.DeleteBlobAsync(blobName);
            return RedirectToAction("ListResources", "Resources");
        }


    }
}
