using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlAsistencia.Data;
using ControlAsistencia.Models;

namespace ControlAsistencia.Controllers
{
    public class CompetenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Competencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competencia.ToListAsync());
        }

        // GET: Competencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencia = await _context.Competencia
                .FirstOrDefaultAsync(m => m.CompetenciaId == id);
            if (competencia == null)
            {
                return NotFound();
            }

            return View(competencia);
        }

        // GET: Competencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenciaId,Codigo,Denominacion,Estado")] Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competencia);
        }

        // GET: Competencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencia = await _context.Competencia.FindAsync(id);
            if (competencia == null)
            {
                return NotFound();
            }
            return View(competencia);
        }

        // POST: Competencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenciaId,Codigo,Denominacion,Estado")] Competencia competencia)
        {
            if (id != competencia.CompetenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciaExists(competencia.CompetenciaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(competencia);
        }

        // GET: Competencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencia = await _context.Competencia
                .FirstOrDefaultAsync(m => m.CompetenciaId == id);
            if (competencia == null)
            {
                return NotFound();
            }

            return View(competencia);
        }

        // POST: Competencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competencia = await _context.Competencia.FindAsync(id);
            _context.Competencia.Remove(competencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciaExists(int id)
        {
            return _context.Competencia.Any(e => e.CompetenciaId == id);
        }
    }
}
