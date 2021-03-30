using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Controllers
{
    [Authorize]
    public class TimeTableController : Controller
    {
        [HttpGet]
        public IActionResult ViewTimeTable()
        {
            return View();
        }
    }
}
