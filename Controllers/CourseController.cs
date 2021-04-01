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
    public class CourseController : Controller
    {
        private readonly PulseDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public CourseController(PulseDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var temp = context.User;
            var faculties = await temp.ToListAsync();
            ViewBag.faculties = faculties;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if(course == null)
            {
                ViewBag.ErrorMessage = "Please Try Again.";
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                context.Add(course);
                await context.SaveChangesAsync();
                return RedirectToAction("ListCourses");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListCourses()
        {

            var temp = context.Courses;
            var courses = await temp.ToListAsync();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.CourseId == id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
           
           
                try {
                    context.Update(course);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewBag.ErrorMessage = "Please try again.";
                    return View("NotFound");
                }
                return RedirectToAction("ListCourses", "Course");
           
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            context.Remove(context.Courses.Single(c=> c.CourseId == id));
            await context.SaveChangesAsync();
            return RedirectToAction("ListCourses","Course");
        }

    }
}
