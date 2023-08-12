﻿using System;
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
    public class KlantenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlantenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klanten
        public async Task<IActionResult> Index()
        {
              return _context.Klant != null ? 
                          View(await _context.Klant.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Klant'  is null.");
        }

        // GET: Klanten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klant == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // GET: Klanten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klanten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Voornaam,Achternaam,Adres,Telefoonnummer,Emailadres,EigenSurfboardDesign")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klant);
        }

        // GET: Klanten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klant == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant.FindAsync(id);
            if (klant == null)
            {
                return NotFound();
            }
            return View(klant);
        }

        // POST: Klanten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Voornaam,Achternaam,Adres,Telefoonnummer,Emailadres,EigenSurfboardDesign")] Klant klant)
        {
            if (id != klant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.Id))
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
            return View(klant);
        }

        // GET: Klanten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klant == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Klanten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klant == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Klant'  is null.");
            }
            var klant = await _context.Klant.FindAsync(id);
            if (klant != null)
            {
                _context.Klant.Remove(klant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlantExists(int id)
        {
          return (_context.Klant?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
