using ForeignKey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Services
{
    public interface IRoutineService
    {
        Task<IEnumerable<Routine>> GetRoutines();
        Task<Routine> GetRoutine(int id);
        void DeleteRoutine(int id);
        Task<Routine> AddRoutine(Routine routine);
    }
}
