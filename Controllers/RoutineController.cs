using ForeignKey.Models;
using ForeignKey.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey.Controllers
{
    public class RoutineController : Controller
    {
        private IRoutineService  _routineService;
        public RoutineController(IRoutineService routineService)
        {
            _routineService = routineService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _routineService.GetRoutines();
            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await _routineService.GetRoutine(id);
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            _routineService.DeleteRoutine(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id=0)
        {
            Routine routine = new Routine();

            if (id != 0)
            {
                routine = await _routineService.GetRoutine(id);
            }
            return View(routine);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Routine routine)
        {
            if (ModelState.IsValid)
            {
                await _routineService.AddRoutine(routine);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
