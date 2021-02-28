using ForeignKey.Models;
using ForeignKey.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _studentService.GetStudents();
            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await _studentService.GetStudent(id);
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
           return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            Student student = new Student();

            if( id > 0)
            {
                student = await _studentService.GetStudent(id);
            }

            var result = new StudentCreateViewModel
            {
                student = student,
                courses = await _courseService.GetCourses(),
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateViewModel student)
        {
            if (ModelState.IsValid)
            {
                var student1 = new Student
                {
                    Id = 0,
                    Name = student.StudentName,
                    CourseId = student.CourseId
                };
              await _studentService.AddStudent(student1);
            }
            return RedirectToAction(nameof(Index));
        }
    }   
}
