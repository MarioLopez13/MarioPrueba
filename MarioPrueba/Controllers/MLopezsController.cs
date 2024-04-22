using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarioPrueba.Data;
using MarioPrueba.Models;

namespace MarioPrueba.Controllers
{
    public class MLopezsController : Controller
    {
        private readonly MarioPruebaContext _context;

        public MLopezsController(MarioPruebaContext context)
        {
            _context = context;
        }

        // GET: MLopezs
        public async Task<IActionResult> Index()
        {
            var marioPruebaContext = _context.MLopez.Include(m => m.carrera);
            return View(await marioPruebaContext.ToListAsync());
        }

        // GET: MLopezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLopez = await _context.MLopez
                .Include(m => m.carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mLopez == null)
            {
                return NotFound();
            }

            return View(mLopez);
        }

        // GET: MLopezs/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "CarreraId");
            return View();
        }

        // POST: MLopezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,activo,PromedioCalificaciones,FechaNacimiento,CarreraId")] MLopez mLopez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mLopez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "CarreraId", mLopez.CarreraId);
            return View(mLopez);
        }

        // GET: MLopezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLopez = await _context.MLopez.FindAsync(id);
            if (mLopez == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "CarreraId", mLopez.CarreraId);
            return View(mLopez);
        }

        // POST: MLopezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,activo,PromedioCalificaciones,FechaNacimiento,CarreraId")] MLopez mLopez)
        {
            if (id != mLopez.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mLopez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MLopezExists(mLopez.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "CarreraId", mLopez.CarreraId);
            return View(mLopez);
        }

        // GET: MLopezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLopez = await _context.MLopez
                .Include(m => m.carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mLopez == null)
            {
                return NotFound();
            }

            return View(mLopez);
        }

        // POST: MLopezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mLopez = await _context.MLopez.FindAsync(id);
            if (mLopez != null)
            {
                _context.MLopez.Remove(mLopez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MLopezExists(int id)
        {
            return _context.MLopez.Any(e => e.Id == id);
        }
    }
}
