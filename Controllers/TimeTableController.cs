using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pulse.Data;
using Pulse.Models;
using Pulse.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Controllers
{
    [Authorize]
    public class TimeTableController : Controller
    {
        private readonly PulseDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public TimeTableController(PulseDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult ViewTimeTable()
        {

            return View();
        }
       
        [HttpPost]
        public async  Task<IActionResult> ViewSchedule(string branch, int semester)
        {
            if(branch == null || semester < 1)
            {
                return View("ViewTimeTable");
            }
            if (ModelState.IsValid)
            {
                var schedule = context.Schedules.FirstOrDefault(s=> s.Branch == branch && s.Semester == semester);
                if(schedule == null)
                {
                    ViewBag.Message = "Schedule is not generated yet!";
                    return View("ViewTimeTable");

                }
                ViewFullScheduleViewModel model = new ViewFullScheduleViewModel();
                model.Schedule = schedule;
                model.Days = new List<TimeTable>();
                model.Days.Add(context.TimeTable.FirstOrDefault(t => t.TimeTableId == schedule.MondayTTId));
                model.Days.Add(context.TimeTable.FirstOrDefault(t => t.TimeTableId == schedule.TuesdayTTId));
                model.Days.Add(context.TimeTable.FirstOrDefault(t => t.TimeTableId == schedule.WednesdayTTId));
                model.Days.Add(context.TimeTable.FirstOrDefault(t => t.TimeTableId == schedule.ThursdayTTId));
                model.Days.Add(context.TimeTable.FirstOrDefault(t => t.TimeTableId == schedule.FridayTTId));

                var temp =  context.Courses;
                List<Course> courses = await temp.ToListAsync();
                ViewBag.Courses = courses;
                return View(model);


            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTimeTable()
        {

            return View();
        }
        //assumptions : one course alloted to exactly one faculty.
        [HttpPost]
        public async Task<IActionResult> CreateTimeTable(Schedule schedule)
        {
            if(schedule == null)
            {
                ViewBag.ErrorMessage = "Please Try Again";
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                //for random numbers generation
                Random r = new Random();
                

                var temp = context.Courses;
                //list of all courses of given branch and semester
                List<Course> courses = await temp.Where(c => c.Semester == schedule.Semester && c.Department == schedule.Branch).ToListAsync();

                List<string> Days = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"} ;                
                
                for(int i=0; i<schedule.NoOfWorkingDays; i++)
                {
                    TimeTable timeTable = new TimeTable();
                    timeTable.Day = Days[i];
                   
                    for(int j = 0; j< schedule.NoOfSlotsEachDay; j++)
                    {
                        
                        int index = r.Next(courses.Count - 1);
                        var course = courses[index];            //get i-th course. so dec lect count of that course. remove the course from list if count becomes 0

                        courses[index].LecturesPerWeek = courses[index].LecturesPerWeek - 1;
                        if (courses[index].LecturesPerWeek == 0)
                        {
                            courses.RemoveAt(index);
                        }
                       
                        switch (j)
                        {
                            case 0:
                                timeTable.Course1Id =course.CourseId;
                                timeTable.Course1 = course;
                                break;
                            case 1:
                                timeTable.Course2Id = course.CourseId;
                                timeTable.Course2 = course;
                                break;
                            case 2:
                                timeTable.Course3Id = course.CourseId;
                                timeTable.Course3 = course;
                                break;
                            case 3:
                                timeTable.Course4Id = course.CourseId;
                                timeTable.Course4 = course;
                                break;
                            case 4:
                                timeTable.Course5Id = course.CourseId;
                                timeTable.Course5 = course;
                                break;
                            case 5:
                                timeTable.Course6Id = course.CourseId;
                                timeTable.Course6 = course;
                                break;
                        }

                    }
                    var tempt = context.Add(timeTable);
                    await context.SaveChangesAsync();

                    var tt = context.TimeTable.Find(timeTable.TimeTableId);
                    switch (i)
                    {
                        case 0:
                            schedule.MondayTT = tt;
                            schedule.MondayTTId = tt.TimeTableId;
                            break;
                        case 1:
                            schedule.TuesdayTT = tt;
                            schedule.TuesdayTTId = tt.TimeTableId;
                            break;
                        case 2:
                            schedule.WednesdayTT = tt;
                            schedule.WednesdayTTId = tt.TimeTableId;
                            break;
                        case 3:
                            schedule.ThursdayTT = tt;
                            schedule.ThursdayTTId = tt.TimeTableId;
                            break;
                        case 4:
                            schedule.FridayTT = tt;
                            schedule.FridayTTId = tt.TimeTableId;
                            break;
                    }

                }

                context.Add(schedule);
                await context.SaveChangesAsync();
                return RedirectToAction("ViewSchedule");
            }
            return View();
        }
    }
}
