using ForeignKey.Models;
using ForeignKey.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _courseService.GetCourses();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _courseService.GetCourse(id);
            return View(data);
        }
        public IActionResult Delete(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var course = new Course();
            if(id > 0)
            {
                course = await _courseService.GetCourse(id);
            }
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Create( Course course)
        {
            if (ModelState.IsValid)
            {
               await _courseService.AddCourse( course);
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
