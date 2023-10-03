using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcaiBrotas.Data;
using AcaiBrotas.Models;
using Microsoft.AspNetCore.Authorization;

namespace AcaiBrotas.Controllers
{
    public class TiposController : Controller
    {
        private readonly AcaiContext _context;

        public TiposController(AcaiContext context)
        {
            _context = context;
        }

        // GET: Tipos
        [Authorize(Roles = "Admin, Estagiario")]
        public async Task<IActionResult> Index()
        {
              return _context.Tipos != null ? 
                          View(await _context.Tipos.ToListAsync()) :
                          Problem("Entity set 'AcaiContext.Tipos'  is null.");
        }

        // GET: Tipos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipos
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // GET: Tipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,Name")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                tipo.TipoId = Guid.NewGuid();
                _context.Add(tipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo);
        }

        // GET: Tipos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        // POST: Tipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TipoId,Name")] Tipo tipo)
        {
            if (id != tipo.TipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExists(tipo.TipoId))
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
            return View(tipo);
        }

        // GET: Tipos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipos
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: Tipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tipos == null)
            {
                return Problem("Entity set 'AcaiContext.Tipos'  is null.");
            }
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo != null)
            {
                _context.Tipos.Remove(tipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExists(Guid id)
        {
          return (_context.Tipos?.Any(e => e.TipoId == id)).GetValueOrDefault();
        }
    }
}
