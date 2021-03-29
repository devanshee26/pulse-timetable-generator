using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pulse.Data;
using Pulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly PulseDbContext _context;
       
        public AccountController(UserManager<IdentityUser> userManager,
                                   SignInManager<IdentityUser> signInManager, PulseDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
           
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser {
                    UserName = model.Email,
                    Email = model.Email
                };


                //identity table user added
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                 //   await signInManager.SignInAsync(user, isPersistent: false);


                    //my user table => user added
                    _context.Add(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("login", "account");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {


            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }



                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError("", "Invalid Login Attempt!");
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("login", "account");
        }

    }
}
