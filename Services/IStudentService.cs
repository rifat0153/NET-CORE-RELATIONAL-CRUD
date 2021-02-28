using ForeignKey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Services
{
   public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        void DeleteStudent(int id);
        Task<Student> AddStudent(Student student);

    }
}
