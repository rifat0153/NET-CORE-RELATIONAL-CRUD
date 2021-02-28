using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Models
{
    public class StudentCreateViewModel
    {
        public IEnumerable<Course> courses { get; set; }
        public Student student { get; set; }
        public int CourseId { get; set; }
        public string StudentName { get; set; }
    }
}
