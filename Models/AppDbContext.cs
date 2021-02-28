using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext( DbContextOptions options ):base(options)
        {
            
        }

        public DbSet <Student> Students{ get; set; }
        public DbSet <Course> Courses{ get; set; }
        public DbSet <Routine> Routines{ get; set; }
    }
}
