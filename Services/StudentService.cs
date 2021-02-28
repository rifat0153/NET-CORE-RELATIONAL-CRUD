using ForeignKey.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.Include(x => x.Course).ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            var data = await _context.Students.FindAsync(id);
            return data;
        }

        public void DeleteStudent(int id)
        {
            var data = _context.Students.Where(x => x.Id == id).FirstOrDefault();

            if(data != null)
            {
                _context.Students.Remove(data);
                _context.SaveChanges();
            }
        }

        public async Task<Student> AddStudent(Student student)
        {
            if( student.Id > 0)
            {
               _context.Entry(student).State = EntityState.Modified;
            }
            else
            {
                _context.Students.Add(student);
            }
            
            await _context.SaveChangesAsync();

            return student;
        }
    }
}
