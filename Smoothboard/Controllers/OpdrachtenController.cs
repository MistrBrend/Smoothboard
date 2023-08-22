using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smoothboard.Data;
using Smoothboard.Models;

namespace Smoothboard.Controllers
{
    public class OpdrachtenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpdrachtenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opdrachten
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Opdracht.Include(o => o.Klant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Opdrachten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Opdracht == null)
            {
                return NotFound();
            }

            var opdracht = await _context.Opdracht
                .Include(o => o.Klant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opdracht == null)
            {
                return NotFound();
            }

            return View(opdracht);
        }

        // GET: Opdrachten/Create
        public IActionResult Create()
        {
            ViewData["KlantId"] = new SelectList(_context.Klant, "Id", "Id");
            return View();
        }

        // POST: Opdrachten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KlantId,DatumGebracht,DatumOpgehaald,AkkoordDesign,SurfboardDesign,Status,Hoogte,Lengte")] Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opdracht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlantId"] = new SelectList(_context.Klant, "Id", "Id", opdracht.KlantId);
            return View(opdracht);
        }

        // GET: Opdrachten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Opdracht == null)
            {
                return NotFound();
            }

            var opdracht = await _context.Opdracht.FindAsync(id);
            if (opdracht == null)
            {
                return NotFound();
            }
            ViewData["KlantId"] = new SelectList(_context.Klant, "Id", "Id", opdracht.KlantId);
            return View(opdracht);
        }

        // POST: Opdrachten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KlantId,DatumGebracht,DatumOpgehaald,AkkoordDesign,SurfboardDesign,Status,Hoogte,Lengte")] Opdracht opdracht)
        {
            if (id != opdracht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opdracht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpdrachtExists(opdracht.Id))
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
            ViewData["KlantId"] = new SelectList(_context.Klant, "Id", "Id", opdracht.KlantId);
            return View(opdracht);
        }

        // GET: Opdrachten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Opdracht == null)
            {
                return NotFound();
            }

            var opdracht = await _context.Opdracht
                .Include(o => o.Klant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opdracht == null)
            {
                return NotFound();
            }

            return View(opdracht);
        }

        // POST: Opdrachten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Opdracht == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Opdracht'  is null.");
            }
            var opdracht = await _context.Opdracht.FindAsync(id);
            if (opdracht != null)
            {
                _context.Opdracht.Remove(opdracht);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpdrachtExists(int id)
        {
          return (_context.Opdracht?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
