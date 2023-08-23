using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smoothboard.Data;
using Smoothboard.Models;

namespace Smoothboard.Controllers
{
    [Authorize]
    public class OpdrachtTestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpdrachtTestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OpdrachtTests
        public async Task<IActionResult> Index()
        {
              return _context.OpdrachtTest != null ? 
                          View(await _context.OpdrachtTest.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.OpdrachtTest'  is null.");
        }

        // GET: OpdrachtTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OpdrachtTest == null)
            {
                return NotFound();
            }

            var opdrachtTest = await _context.OpdrachtTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opdrachtTest == null)
            {
                return NotFound();
            }

            return View(opdrachtTest);
        }

        // GET: OpdrachtTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpdrachtTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KlantNaam,DatumGebracht,DatumOpgehaald,AkkoordDesign,SurfboardDesign,Status,Lengte,Breedte")] OpdrachtTest opdrachtTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opdrachtTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opdrachtTest);
        }

        // GET: OpdrachtTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OpdrachtTest == null)
            {
                return NotFound();
            }

            var opdrachtTest = await _context.OpdrachtTest.FindAsync(id);
            if (opdrachtTest == null)
            {
                return NotFound();
            }
            return View(opdrachtTest);
        }

        // POST: OpdrachtTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KlantNaam,DatumGebracht,DatumOpgehaald,AkkoordDesign,SurfboardDesign,Status,Lengte,Breedte")] OpdrachtTest opdrachtTest)
        {
            if (id != opdrachtTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opdrachtTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpdrachtTestExists(opdrachtTest.Id))
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
            return View(opdrachtTest);
        }

        // GET: OpdrachtTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OpdrachtTest == null)
            {
                return NotFound();
            }

            var opdrachtTest = await _context.OpdrachtTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opdrachtTest == null)
            {
                return NotFound();
            }

            return View(opdrachtTest);
        }

        // POST: OpdrachtTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OpdrachtTest == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OpdrachtTest'  is null.");
            }
            var opdrachtTest = await _context.OpdrachtTest.FindAsync(id);
            if (opdrachtTest != null)
            {
                _context.OpdrachtTest.Remove(opdrachtTest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpdrachtTestExists(int id)
        {
          return (_context.OpdrachtTest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
