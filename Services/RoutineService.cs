using ForeignKey.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly AppDbContext _context;
        public RoutineService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Routine> AddRoutine(Routine routine)
        {
            if(routine.Id != 0)
            {
                _context.Entry(routine).State = EntityState.Modified;
            }
            else
            {
                _context.Routines.Add(routine);
            }
            
            await _context.SaveChangesAsync();

            return routine;
        }

        public void DeleteRoutine(int id)
        {
            var data = _context.Routines.Find(id);

            if(data != null)
            {
                _context.Routines.Remove(data);
                _context.SaveChanges();
            }
        }

        public async Task<Routine> GetRoutine(int id)
        {
            var data = await _context.Routines.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<Routine>> GetRoutines()
        {
            var data = await _context.Routines.ToListAsync();
            return data;
   
        }
    }
}
