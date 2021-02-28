using ForeignKey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Services
{
   public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        void DeleteCourse(int id);
        Task<Course> AddCourse(Course course);

    }
}
