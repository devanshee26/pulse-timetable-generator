using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Controllers
{
    [Authorize]
    public class ResourcesController : Controller
    {
        [HttpGet]
        public IActionResult ViewResources()
        {
            return View();
        }
    }
}
