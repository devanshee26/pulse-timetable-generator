using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pulse.Data;
using Pulse.Models;
using Pulse.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Controllers
{
   [Authorize]
   //[Route("blobs")]
    public class ResourcesController : Controller
    {
        private readonly IUploadAzureService service;
        private readonly PulseDbContext context;

        public ResourcesController(IUploadAzureService service, PulseDbContext context)
        {
            this.service = service;
            this.context = context;
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
            IEnumerable<Resources> resources1 = context.Resources.AsEnumerable<Resources>();
            
            var CurrentUserId = context.User.SingleOrDefault(x => x.Email == User.Identity.Name).Id;
            List<Resources> MyResources = new List<Resources>();
            List<Resources> Others = new List<Resources>();
            foreach(var rcs in resources1){
                if(rcs.UserId == CurrentUserId)
                {
                    MyResources.Add(rcs);
                }
                else
                {
                    Others.Add(rcs);
                }
            }
            ViewBag.MyResources = MyResources;
            ViewBag.Others = Others;
            return View(resources);
        }
        [Authorize(Roles ="Admin, Faculty")]
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Faculty")]
        [HttpPost]
        public async Task<IActionResult> UploadFile(Resources resources)
        {
            UploadFileRequest request = new UploadFileRequest();
            
            request.FileName = resources.FileName;
            string fileName = Path.GetFileNameWithoutExtension(resources.ImagePath.FileName);
            string extension = Path.GetExtension(resources.ImagePath.FileName);
            // fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            fileName = fileName + extension;
            Console.WriteLine(fileName);

            var currentuser = context.User.SingleOrDefault(x => x.Email == User.Identity.Name);

            request.FilePath = "D:\\00\\"+ fileName;
            resources.SubjectId = 1;
            resources.UserId = currentuser.Id;
            
            //upload file on azure
            await service.UploadFileBlobAsync(request.FilePath, request.FileName);
            
            //save file data in db
            context.Add(resources);
            await context.SaveChangesAsync();

            return RedirectToAction("ListResources", "Resources");
        }
        [Authorize(Roles = "Admin, Faculty")]
        [HttpGet]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            await service.DeleteBlobAsync(blobName);
            context.Remove(context.Resources.Single(a => a.FileName == blobName));
            await context.SaveChangesAsync();
            return RedirectToAction("ListResources", "Resources");
        }


    }
}
