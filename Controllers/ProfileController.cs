using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pulse.Data;
using Pulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly PulseDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;


        public ProfileController(PulseDbContext context ,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public  IActionResult ViewProfile(int? userid)
        {
            if (ModelState.IsValid)
            {
                if(userid != null)
                {
                    
                    var otheruser = context.User.SingleOrDefault(x => x.Id == userid);
                    return View(otheruser);
                }
                var currentuser = context.User.SingleOrDefault(x => x.Email == User.Identity.Name);
                return View(currentuser);
            }
            return View();
           
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            if (ModelState.IsValid)
            {
                var currentuser = context.User.SingleOrDefault(x => x.Email == User.Identity.Name);
                return View(currentuser);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(int id, [Bind("Id,Email,Password,Name,Semester,Branch,Role")]User model)
        {
            if (id != model.Id)
            {
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(model);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("ViewProfile", "Profile");
            }
            return View(model) ;
        }
        private bool UserExists(int id)
        {
            return context.User.Any(e => e.Id == id);
        }
    }
}
