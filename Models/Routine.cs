using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string CourseId { get; set; }
        
    }
}
