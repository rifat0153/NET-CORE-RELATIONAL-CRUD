using ForeignKey.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Course> AddCourse( Course course)
        {
            if(course.Id > 0 )
            {
                _context.Entry(course).State = EntityState.Modified;
            }
            else {
                _context.Courses.Add(course);
             
            }
            await _context.SaveChangesAsync();

            return course;
        }
        public void DeleteCourse(int id)
        {
            var data = _context.Courses.Find(id);

            if(data != null)
            {
                _context.Courses.Remove(data);
                _context.SaveChanges();
            }
        }

        public void DeleteCourse()
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
